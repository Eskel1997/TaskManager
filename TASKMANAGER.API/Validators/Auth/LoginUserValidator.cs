using FluentValidation;
using TASKMANAGER.INFRASTRUCTURE.Commands.Auth;

namespace TASKMANAGER.API.Validators.Auth
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("The value provided is not an email address")
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Value is required");
        }
    }
}
