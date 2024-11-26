using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Auth.Role.UserToRole;

public sealed class UserToRoleValidator : AbstractValidator<UserToRoleRequest>
{
    public UserToRoleValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.RoleName).NotEmpty();
    }
}
