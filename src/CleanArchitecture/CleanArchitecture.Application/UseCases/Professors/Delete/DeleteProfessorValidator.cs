using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Professors.Delete;

public sealed class DeleteProfessorValidator : AbstractValidator<DeleteProfessorRequest>
{
    public DeleteProfessorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
    }
}
