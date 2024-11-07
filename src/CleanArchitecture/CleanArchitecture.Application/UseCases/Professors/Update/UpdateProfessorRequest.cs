using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Update
{
    public sealed record UpdateProfessorRequest(
        int Id, string Name, string Email, string Password) : IRequest<UpdateProfessorResponse>;
}
