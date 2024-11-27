using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Auth.ForgotPassword;

public sealed class ForgotPasswordHandler : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _emailSender;

    public ForgotPasswordHandler(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
    }

    public async Task<ForgotPasswordResponse> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        if (request.Email is null)
            return new ForgotPasswordResponse { Message = "Email is required" };

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new ForgotPasswordResponse { Message = "User not found." };

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(resetToken));

        var resetUrl = $"https://localhost:7078/api/Auth/reset-password?email={request.Email}&token={encodedToken}";

        await _emailSender.SendEmailAsync(user.Email, "Password Reset", $"Click <a href='{resetUrl}'>here</a> to reset your password.");

        return new ForgotPasswordResponse { Message = "Password reset link has been sent to your email." };
        }
}
