using MediatR;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Team
{
    public class CreateTeamCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}
