using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.Login {

    public record LoginRequest(
        string Email, string Password) : IRequest<LoginResponse>;


}
