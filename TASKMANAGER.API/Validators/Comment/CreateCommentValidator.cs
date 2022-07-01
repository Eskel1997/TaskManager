using FluentValidation;

namespace TASKMANAGER.API.Validators.Comment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentModel>
    {
        public CreateCommentValidator()
        {
            RuleFor(p => p.Comment)
                .NotNull().NotEmpty().WithMessage("Value is required");
        }
    }
}
