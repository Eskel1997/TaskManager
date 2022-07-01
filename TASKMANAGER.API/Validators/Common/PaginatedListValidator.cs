using FluentValidation;
using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.API.Validators.Common
{
    public class PaginatedListValidator : AbstractValidator<PaginatedList>
    {
        public PaginatedListValidator()
        {
            RuleFor(p => p.PageNumber)
                .NotNull().NotEmpty().WithMessage("Value is required")
                .GreaterThan(0).WithMessage("Min value is 1");
            RuleFor(p => p.PageSize)
                .NotNull().NotEmpty().WithMessage("Value is required")
                .GreaterThanOrEqualTo(5).WithMessage("Min value is 5");
        }
    }
}
