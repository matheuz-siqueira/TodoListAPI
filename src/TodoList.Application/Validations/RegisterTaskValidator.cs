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

        RuleFor(task => task.Type)
            .IsInEnum()
            .NotEmpty().WithMessage("task must have a category");

        RuleFor(task => task.StartDate)
            .NotEmpty().WithMessage("start date cannot be empty");

        RuleFor(task => task.FinishDate)
            .NotEmpty().WithMessage("finish date cannot be empty");

        RuleFor(task => task.FinishDate)
            .GreaterThan(task => task.FinishDate)
            .WithMessage("completion date must be greater than start date");
    }
}
