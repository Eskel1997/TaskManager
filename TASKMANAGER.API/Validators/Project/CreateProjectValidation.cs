using FluentValidation;
using TASKMANAGER.API.ViewModels.Project;

namespace TASKMANAGER.API.Validators.Project
{
    public class CreateProjectValidation : AbstractValidator<CreateProjectModel>
    {
        public CreateProjectValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.TeamId)
                .NotNull().WithMessage("Value is required");
        }
    }
}
