using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Delete;

public sealed class DeleteProfessorHandler : IRequestHandler<DeleteProfessorRequest, DeleteProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public DeleteProfessorHandler(IProfessorRepository professorRepository, IUnitOfWork uof, IMapper mapper)
    {
        _professorRepository = professorRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<DeleteProfessorResponse> Handle(DeleteProfessorRequest request, CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.Get(request.id, cancellationToken);
        if (professor == null) return default;

        _professorRepository.Delete(professor);
        await _uof.Commit(cancellationToken);

        return _mapper.Map<DeleteProfessorResponse>(professor);
    }
}
