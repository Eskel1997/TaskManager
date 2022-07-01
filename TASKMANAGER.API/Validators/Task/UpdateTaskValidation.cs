using FluentValidation;
using TASKMANAGER.API.ViewModels.Task;

namespace TASKMANAGER.API.Validators.Task
{
    public class UpdateTaskValidation : AbstractValidator<UpdateTaskModel>
    {
        public UpdateTaskValidation()
        {
            RuleFor(p => p.Description)
                .NotNull().NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage("Value is required"); 
            RuleFor(p => p.ProjectId)
                .NotNull().WithMessage("Value is required");
        }
    }
}
