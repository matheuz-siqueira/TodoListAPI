using FluentValidation;
using TodoList.Application.DTOs.Note;

namespace TodoList.Application.Validations;

public class UpdateNoteValidator : AbstractValidator<UpdateNoteRequestJson>
{
    public UpdateNoteValidator()
    {
        RuleFor(note => note.Annotation).NotEmpty().WithMessage("enter the annotation text");
    }
}
