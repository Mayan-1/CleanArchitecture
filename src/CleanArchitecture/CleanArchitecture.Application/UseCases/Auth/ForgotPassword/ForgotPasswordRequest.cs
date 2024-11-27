using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.ForgotPassword
{
    public sealed record ForgotPasswordRequest(string Email) 
        : IRequest<ForgotPasswordResponse>;
    
    
}
