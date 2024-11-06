using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.GetAll;

public sealed class GetAllProfessorHandler : IRequestHandler<GetAllProfessorRequest, ICollection<GetAllProfessorResponse>>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IMapper _mapper;

    public GetAllProfessorHandler(IProfessorRepository professorRepository, IMapper mapper)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<GetAllProfessorResponse>> Handle(GetAllProfessorRequest request, CancellationToken cancellationToken)
    {
        var professors = await _professorRepository.GetAll(cancellationToken);
        return _mapper.Map<ICollection<GetAllProfessorResponse>>(professors);
    }
}
