using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Get;

public class GetProfessorHandler : IRequestHandler<GetProfessorRequest, GetProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IMapper _mapper;

    public GetProfessorHandler(IProfessorRepository professorRepository, IMapper mapper)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
    }

    public async Task<GetProfessorResponse> Handle(GetProfessorRequest request, CancellationToken cancellationToken)
    {
        var profesor = await _professorRepository.Get(request.Id, cancellationToken);
        if (profesor == null) return default;

        return _mapper.Map<GetProfessorResponse>(profesor);
    }
}
