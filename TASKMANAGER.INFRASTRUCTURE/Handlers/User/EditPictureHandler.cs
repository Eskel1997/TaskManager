using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class EditPictureHandler : IRequestHandler<EditPictureCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public EditPictureHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(EditPictureCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            user.ChangePicture(request.PictureUrl);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
