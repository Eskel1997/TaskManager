using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Team
{
    public class UpdateTeamCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }
    }
}
