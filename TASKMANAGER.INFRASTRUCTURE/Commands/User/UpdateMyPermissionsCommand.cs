using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models.User;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.User
{
    public class UpdateMyPermissionsCommand : IRequest<UserPermissionsModel>, IAuth
    {
        public long UserId { get; set; }
        public UserPermissionsModel Permissions {get; set;}
        public UpdateMyPermissionsCommand(UserPermissionsModel permissions)
        {
            Permissions = permissions;
        }
    }
}
