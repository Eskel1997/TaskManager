using FluentValidation;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;

namespace TASKMANAGER.API.Validators.User
{
    public class AddUserValidator : AbstractValidator<RegisterCommand>
    {
        public AddUserValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("Value is required");
        }
    }
}
