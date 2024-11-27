using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Auth.ResetPassword;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordValidator()
    {
        /// no validation
    }
}
