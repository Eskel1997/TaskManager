using FluentValidation;
using TASKMANAGER.API.ViewModels.Team;

namespace TASKMANAGER.API.Validators.Team
{
    public class UpdateTeamValidator : AbstractValidator<UpdateTeamModel>
    {
        public UpdateTeamValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Value is required")
                .NotEmpty().WithMessage("Value is required")
                .MaximumLength(150).WithMessage("Maximum length is 150 characters");
        }
    }
}
