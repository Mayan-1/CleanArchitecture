using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Auth.Login;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
            

    }
}
