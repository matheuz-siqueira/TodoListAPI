using FluentValidation;
using TodoList.Application.DTOs.Note;

namespace TodoList.Application.Validations;

public class RegisterNoteValidator : AbstractValidator<RegisterNoteRequestJson>
{
    public RegisterNoteValidator()
    {
        RuleFor(note => note.Annotation)
            .NotEmpty().WithMessage("annotation field cannot be empty");
    }
}
