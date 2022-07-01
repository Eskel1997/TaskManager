using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class UpdateUserPermissionsHandler : IRequestHandler<UpdateUserPermissionsCommand, UserPermissionsModel>
    {
        private readonly IPermissionsService _permissionsService;
        private readonly IUserRepository _userRepository;
        public UpdateUserPermissionsHandler(
            IPermissionsService permissions,
            IUserRepository userRepository)
        {
            _permissionsService = permissions;
            _userRepository = userRepository;
        }
        public async Task<UserPermissionsModel> Handle(UpdateUserPermissionsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.PublicId);
            return await _permissionsService.UpdateUserPermissions(user.Id, request.Permissions);
        }
    }
}
