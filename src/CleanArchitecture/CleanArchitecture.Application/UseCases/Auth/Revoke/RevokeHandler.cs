using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.UseCases.Auth.Revoke;

public class RevokeHandler : IRequestHandler<RevokeRequest, RevokeResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RevokeHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RevokeResponse> Handle(RevokeRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new ArgumentNullException();

        user.RefreshToken = string.Empty;

        await _userManager.UpdateAsync(user);

        return new RevokeResponse
        {
            Message = "Revoke successful"
        };
    }
}
