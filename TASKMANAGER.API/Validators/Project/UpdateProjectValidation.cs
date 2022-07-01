using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TASKMANAGER.API.ViewModels.Project;

namespace TASKMANAGER.API.Validators.Project
{
    public class UpdateProjectValidation : AbstractValidator<UpdateProjectModel>
    {
        public UpdateProjectValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.TeamId)
                .NotNull().WithMessage("Value is required");
        }
    }
}
