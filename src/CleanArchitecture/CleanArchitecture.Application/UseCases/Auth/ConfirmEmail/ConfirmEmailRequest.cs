using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.ConfirmEmail
{
    public sealed record ConfirmEmailRequest(string UserId, string Token) : IRequest<ConfirmEmailResponse>;
}
