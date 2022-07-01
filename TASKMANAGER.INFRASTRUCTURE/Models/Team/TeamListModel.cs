using System.Collections.Generic;
using TASKMANAGER.DB.Helpers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Team
{
    public class TeamListModel
    {
        public IList<TeamListItemModel> Results { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
