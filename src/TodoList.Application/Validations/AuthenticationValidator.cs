using FluentValidation;
using TodoList.Application.DTOs.User;

namespace TodoList.Application.Validations;

public class AuthenticationValidator : AbstractValidator<AuthenticationRequestJson>
{
    public AuthenticationValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("email cannot be empty")
            .EmailAddress().WithMessage("email needs to be valid");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("password cannot be empty")
            .MinimumLength(8).WithMessage("password must be at least 8 characters");
    }
}
