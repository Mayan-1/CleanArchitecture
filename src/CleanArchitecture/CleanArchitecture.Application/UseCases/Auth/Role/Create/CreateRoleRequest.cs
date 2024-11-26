using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Auth.Role.Create
{
    public sealed record CreateRoleRequest(string RoleName) : IRequest<CreateRoleResponse>;
}
