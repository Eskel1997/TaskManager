using FluentValidation;

namespace TASKMANAGER.API.Validators.Comment
{
    public class UpdateCommentValidator :AbstractValidator<UpdateCommentModel>
    {
        public UpdateCommentValidator()
        {
            RuleFor(p => p.Comment)
                .NotNull().NotEmpty().WithMessage("Value is required");
            RuleFor(p => p.PublicId)
                .NotNull().NotEmpty().WithMessage("Value is required");
        }
    }
}
