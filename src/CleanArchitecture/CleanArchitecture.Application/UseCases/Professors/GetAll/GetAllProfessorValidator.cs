using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Professors.GetAll;

public sealed class GetAllProfessorValidator : AbstractValidator<GetAllProfessorRequest>
{
    public GetAllProfessorValidator()
    {
        // no validation
    }
}
