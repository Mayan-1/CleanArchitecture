using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Delete;

public sealed record DeleteProfessorRequest(int id)
    : IRequest<DeleteProfessorResponse>;

