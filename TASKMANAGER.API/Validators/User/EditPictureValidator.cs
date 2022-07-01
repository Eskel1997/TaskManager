using FluentValidation;
using TASKMANAGER.API.ViewModels.User;

namespace TASKMANAGER.API.Validators.User
{
    public class EditPictureValidator : AbstractValidator<EditPictureModel>
    {
        public EditPictureValidator()
        {
            RuleFor(p => p.PictureUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage("Value is required");
        }
    }
}
