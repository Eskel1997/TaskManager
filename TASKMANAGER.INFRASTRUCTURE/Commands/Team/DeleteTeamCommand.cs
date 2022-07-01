using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Team
{
    public class DeleteTeamCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }
        public DeleteTeamCommand(Guid publicId)
        {
            PublicId = publicId;
        }
    }
}
