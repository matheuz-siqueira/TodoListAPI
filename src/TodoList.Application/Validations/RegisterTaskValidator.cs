using FluentValidation;
using TodoList.Application.DTOs.Task;

namespace TodoList.Application.Validations;

public class RegisterTaskValidator : AbstractValidator<RegisterTaskRequestJson>
{
    public RegisterTaskValidator()
    {
        RuleFor(task => task.Title)
            .NotEmpty().WithMessage("title cannot be empty")
            .MinimumLength(3).WithMessage("title must have at least 3 characters");

        RuleFor(task => task.Type).IsInEnum().WithMessage("task must have a category");

        RuleFor(task => task.FinishDate)
            .NotEmpty().WithMessage("finish date cannot be empty");
    }
}
