using FluentValidation;
using TodoList.Application.DTOs.User;

namespace TodoList.Application.Validations;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequestJson>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("name cannot be empty")
            .MinimumLength(3).WithMessage("name must be at least 3 characters");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("email cannot be empty")
            .EmailAddress().WithMessage("email needs to be valid");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("password cannot be empty")
            .MinimumLength(8).WithMessage("password must be at least 8 characters");
    }
}
