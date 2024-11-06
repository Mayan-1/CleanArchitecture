using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.GetAll;

public sealed record GetAllProfessorRequest : IRequest<ICollection<GetAllProfessorResponse>>;
