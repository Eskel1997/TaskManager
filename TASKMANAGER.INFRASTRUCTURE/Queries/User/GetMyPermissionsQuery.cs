using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models.User;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.User
{
    public class GetMyPermissionsQuery : IRequest<UserPermissionsModel>, IAuth
    {
        public long UserId { get; set; }
    }
}
