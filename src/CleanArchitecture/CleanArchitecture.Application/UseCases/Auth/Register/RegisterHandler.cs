using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.UseCases.Auth.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    private readonly IProfessorRepository _professorRepository;


    public RegisterHandler(ITokenService tokenService,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        IUnitOfWork uof,
        IMapper mapper,
        IProfessorRepository professorRepository)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _uof = uof;
        _mapper = mapper;
        _professorRepository = professorRepository;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var professor = _mapper.Map<Professor>(request);

        _professorRepository.Create(professor);

        var userExists = await _userManager.FindByNameAsync(request.Name!);

        if (userExists != null)
            throw new InvalidOperationException("User already exists");

        var UserName = request.Name.Replace(" ", "_");

        ApplicationUser user = new()
        {
            UserName = UserName,
            SecurityStamp = Guid.NewGuid().ToString(),
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password!);
        await _uof.Commit(cancellationToken);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
            throw new InvalidOperationException($"User creation failed. Erros {errors}");
        }

        return new RegisterResponse { Status = "Sucess", Message = "User created sucessfully" };
    }
}
