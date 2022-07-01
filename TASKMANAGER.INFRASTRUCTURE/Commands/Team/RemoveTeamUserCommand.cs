using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Team
{
    public class RemoveTeamUserCommand : IRequest<Unit>
    {
        public Guid PublicId { get; set; }
        public Guid UserId { get; set; }

        public RemoveTeamUserCommand(Guid publicId, Guid userId)
        {
            PublicId = publicId;
            UserId = userId;
        }
    }
}
