using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.UseCases.Professors.Create;

public class CreateProfessorHandler
{
    private readonly IProfessorRepository _professorRepository;

    public CreateProfessorHandler(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }

    public async Task<CreateProfessorResponse> Handle(CreateProfessorRequest createProfessorRequest, 
        CancellationToken cancellationToken)
    {
        var professor = new Professor
        {
            Name = createProfessorRequest.Name,
            Email = createProfessorRequest.Email,
            Password = createProfessorRequest.Password,
        };

        _professorRepository.Create(professor);


        var professorResponse = new CreateProfessorResponse
        {
            Id = professor.Id,
            Name = professor.Name,
            Email = professor.Email,
            Password = professor.Password,
        };

        return professorResponse;

    }
}
