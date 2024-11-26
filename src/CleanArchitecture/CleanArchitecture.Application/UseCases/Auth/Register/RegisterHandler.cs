using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace CleanArchitecture.Application.UseCases.Auth.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    private readonly IProfessorRepository _professorRepository;
    private readonly IEmailSender _sender;


    public RegisterHandler(UserManager<ApplicationUser> userManager,
        IUnitOfWork uof,
        IMapper mapper,
        IProfessorRepository professorRepository,
        IEmailSender sender)
    {
        _userManager = userManager;
        _uof = uof;
        _mapper = mapper;
        _professorRepository = professorRepository;
        _sender = sender;
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

        await SendConfirmationEmail(user, "https://localhost:7078");

        return new RegisterResponse { Status = "Sucess", Message = "User created sucessfully" };
    }

    private async Task SendConfirmationEmail(ApplicationUser user, string baseUrl) 
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

        var confirmationLink = $"{baseUrl}/api/auth/confirm-email?userId={user.Id}&token={encodedToken}";

        var subject = "Confirmação de Registro";
        var message = $"Por favor, confirme seu registro clicando no link a seguir: <a href='{confirmationLink}'>Confirmar E-mail</a>";

        await _sender.SendEmailAsync(user.Email, subject, message);
    }
}
