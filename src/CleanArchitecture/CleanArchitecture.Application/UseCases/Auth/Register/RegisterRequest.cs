using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Auth.Register
{
    public record RegisterRequest(string Name, string Email, string Password) : IRequest<RegisterResponse>;
    
    
}
