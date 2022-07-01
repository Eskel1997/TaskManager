using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class UpdateMyPermissionsHandler : IRequestHandler<UpdateMyPermissionsCommand, UserPermissionsModel>
    {

        private readonly IPermissionsService _permissionsService;
        public UpdateMyPermissionsHandler(
            IPermissionsService permissions)
        {
            _permissionsService = permissions;
        }
        public async Task<UserPermissionsModel> Handle(UpdateMyPermissionsCommand request, CancellationToken cancellationToken)
        {
           return await _permissionsService.UpdateUserPermissions(request.UserId, request.Permissions);
        }
    }
}
