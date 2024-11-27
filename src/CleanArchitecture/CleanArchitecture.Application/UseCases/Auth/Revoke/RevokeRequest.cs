using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.Revoke
{
    public sealed record RevokeRequest(string Email) : IRequest<RevokeResponse>;
    
    
}
