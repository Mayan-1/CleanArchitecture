using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.Role.UserToRole
{
    public sealed record UserToRoleRequest(string Email, string RoleName) : IRequest<UserToRoleResponse>;
}
