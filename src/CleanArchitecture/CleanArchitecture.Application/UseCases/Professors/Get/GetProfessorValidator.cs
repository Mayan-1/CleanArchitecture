using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Professors.Get;

public sealed class GetProfessorValidator : AbstractValidator<GetProfessorRequest>
{
    public GetProfessorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
    }
}
