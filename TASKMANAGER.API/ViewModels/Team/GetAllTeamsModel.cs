using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.API.ViewModels.Team
{
    public class GetAllTeamsModel : PaginatedList
    {
        public string Search { get; set; }
    }
}
