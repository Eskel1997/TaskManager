using FluentValidation;
using TASKMANAGER.API.ViewModels.User;

namespace TASKMANAGER.API.Validators.User
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordValidator()
        {
            RuleFor(p => p.OldPassword)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.RepeatedPassword)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.NewPassword)
                .Equal(p => p.RepeatedPassword)
                .WithMessage("Passwords must be the same");
            RuleFor(p => p.OldPassword)
                .NotEqual(p => p.NewPassword)
                .WithMessage("Old and new password cannot be the same");
        }
    }
}
