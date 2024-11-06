using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Professors.Create;

public class CreateProfessorHandler : IRequestHandler<CreateProfessorRequest, CreateProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public CreateProfessorHandler(IProfessorRepository professorRepository, IUnitOfWork uof, IMapper mapper)
    {
        _professorRepository = professorRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<CreateProfessorResponse> Handle(CreateProfessorRequest request, 
        CancellationToken cancellationToken)
    {
        var professor = _mapper.Map<Professor>(request);
        
        _professorRepository.Create(professor);

        await _uof.Commit(cancellationToken);

        return _mapper.Map<CreateProfessorResponse>(professor);

    }
}
