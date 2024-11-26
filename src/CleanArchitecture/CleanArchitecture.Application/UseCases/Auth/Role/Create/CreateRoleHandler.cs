using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.UseCases.Auth.Role.Create;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateRoleHandler(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);

        if (!roleExist)
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(request.RoleName));

            if (roleResult.Succeeded)
            {
                return new CreateRoleResponse
                {
                    Message = $"Role {request.RoleName} added successfully"
                };
            }
            else
            {
                return new CreateRoleResponse
                {
                    Message = $"Issue adding the new {request.RoleName} role"
                };
            }
        }

        return new CreateRoleResponse
        {
            Message = $"Role already exist."
        };
    }
}
