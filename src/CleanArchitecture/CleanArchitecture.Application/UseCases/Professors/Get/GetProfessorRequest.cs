using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Get
{
    public sealed record GetProfessorRequest(int Id) : IRequest<GetProfessorResponse>;
}
