using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Professors.Update;

public sealed class UpdateProfessorValidator : AbstractValidator<UpdateProfessorRequest>
{
    public UpdateProfessorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.")
           .MinimumLength(3).WithMessage("Name length must be at least 3.")
           .MaximumLength(45).WithMessage("Name length must not exceed 45.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty")
            .MinimumLength(3).WithMessage("Email length must be at least 3.")
            .MaximumLength(45).WithMessage("Email length must not exceed 45.")
            .EmailAddress().WithMessage("Invalid Email Adress.");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                   .MinimumLength(8).WithMessage("Password length must be at least 8.")
                   .MaximumLength(16).WithMessage("Password length must not exceed 16.")
                   .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                   .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                   .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                   .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one (!? *.).");
    }
}
