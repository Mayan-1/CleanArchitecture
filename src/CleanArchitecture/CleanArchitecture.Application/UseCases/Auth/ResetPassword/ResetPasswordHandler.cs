using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace CleanArchitecture.Application.UseCases.Auth.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ResetPasswordHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
            return new ResetPasswordResponse { Message = "Fields are required" };

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new ResetPasswordResponse { Message = "User not found." };

        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));

        var result = await _userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);

        if (result.Succeeded)
            return new ResetPasswordResponse { Message = "Password reset sucessfully" };

        return new ResetPasswordResponse { Message = "Error reseting password" };
    }
}
