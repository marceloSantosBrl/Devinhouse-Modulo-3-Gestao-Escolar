using FluentValidation;

namespace GestaoEscolar_M3S01.Api.Subject.Validatior;

public class SubjectValidator: AbstractValidator<Model.Subject>
{
    public SubjectValidator()
    {
        RuleFor(s => s.Name).NotEmpty();
    }
}