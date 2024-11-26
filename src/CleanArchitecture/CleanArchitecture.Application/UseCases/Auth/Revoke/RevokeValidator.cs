using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Auth.Revoke;

public sealed class RevokeValidator : AbstractValidator<RevokeRequest>
{
    public RevokeValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
    }
}
