using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Auth.Role.Create;

public sealed class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.RoleName).NotEmpty();
    }
}
