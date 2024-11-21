using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Delete;

public sealed record DeleteProfessorRequest(int Id)
    : IRequest<DeleteProfessorResponse>;

