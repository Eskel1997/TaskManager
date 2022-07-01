using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models.User;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.User
{
    public class UpdateUserPermissionsCommand : IRequest<UserPermissionsModel>, IAuth
    {
        public string PublicId {get ;set;}
        public UserPermissionsModel Permissions {get; set;}
        public long UserId {get; set;}
        public UpdateUserPermissionsCommand(string publicId, UserPermissionsModel permissions)
        {
            PublicId = publicId;
            Permissions = permissions;
        }
    }
}
