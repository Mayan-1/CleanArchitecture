using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.UseCases.Auth.Role.UserToRole;

public class UserToRoleHandler : IRequestHandler<UserToRoleRequest, UserToRoleResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public UserToRoleHandler(ITokenService tokenService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<UserToRoleResponse> Handle(UserToRoleRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user != null)
        {
            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            if (result.Succeeded)
            {
                return new UserToRoleResponse
                {
                    Message = $"User {user.Email} added to the {request.RoleName} role"
                };
            }
            else
            {
                return new UserToRoleResponse
                {
                    Message = $"Error: Unable to add user {user.Email} to the {request.RoleName} role"
                };
            }
        }
        
        return new UserToRoleResponse
        {
            Message = "Unable to find user"
        };
    }
}
