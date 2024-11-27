using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CleanArchitecture.Application.UseCases.Auth.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public LoginHandler(ITokenService tokenService,
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email!);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password!))
            throw new InvalidOperationException("Invalid email or password.");

        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = _tokenService.GenerateAcessToken(authClaims,
            _configuration);

        var refreshToken = _tokenService.GenerateRefreshToken();

        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
            out int refreshTokenValidityInMinutes);

        user.RefreshTokenExpiryTime =
            DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

        user.RefreshToken = refreshToken;

        await _userManager.UpdateAsync(user);

        var response = new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = refreshToken,
            Expiration = token.ValidTo,
        };

        return response;


    }
}
