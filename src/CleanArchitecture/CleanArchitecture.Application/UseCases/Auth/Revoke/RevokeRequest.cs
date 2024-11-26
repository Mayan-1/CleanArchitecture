using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Auth.Revoke
{
    public sealed record RevokeRequest(string UserName) : IRequest<RevokeResponse>;
    
    
}
