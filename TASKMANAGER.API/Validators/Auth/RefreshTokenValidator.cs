using FluentValidation;
using TASKMANAGER.INFRASTRUCTURE.Commands.Auth;

namespace TASKMANAGER.API.Validators.Auth
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(p => p.RefreshToken)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.Token)
                .NotEmpty().WithMessage("Value is required");
        }
    }
}
