using FluentValidation;
using TodoList.Application.DTOs.User;

namespace TodoList.Application.Validations;

public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordRequestJson>
{
    public UpdatePasswordValidator()
    {
        RuleFor(r => r.CurrentPassword)
            .NotEmpty().WithMessage("current password cannot be empty")
            .MinimumLength(8).WithMessage("current password must be at least 8 characters");

        RuleFor(r => r.NewPassword)
            .NotEmpty().WithMessage("new password cannot be empty")
            .MinimumLength(8).WithMessage("new password must be at least 8 characters");
    }
}
