using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Team
{
    public class GetAllTeamsQuery : PaginatedList, IRequest<TeamListModel>, IAuth
    {
        public long UserId { get; set; }
        public string Search { get; set; }
    }
}
