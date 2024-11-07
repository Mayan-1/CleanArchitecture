using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Professors.Update;

public class UpdateProfessorHandler : IRequestHandler<UpdateProfessorRequest, UpdateProfessorResponse>
{
    private IProfessorRepository _professorRepository;
    private IMapper _mapper;
    private IUnitOfWork _uof;

    public UpdateProfessorHandler(IProfessorRepository professorRepository, IMapper mapper, IUnitOfWork uof)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
        _uof = uof;
    }

    public async Task<UpdateProfessorResponse> Handle(UpdateProfessorRequest request, CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.Get(request.Id, cancellationToken);
        if (professor == null)
            return default;

        professor.Name = request.Name;
        professor.Email = request.Email;
        professor.Password = request.Password;

        _professorRepository.Update(professor);
        await _uof.Commit(cancellationToken);
        return _mapper.Map<UpdateProfessorResponse>(professor);

       
    }

}
