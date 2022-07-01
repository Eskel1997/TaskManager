using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Team
{
    public class AddTeamUserCommand : IRequest<Unit>, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }
        public Guid TeamUserId { get; set; }
        public AddTeamUserCommand(Guid publicId, Guid userId)
        {
            PublicId = publicId;
            TeamUserId = userId;
        }
    }
}
