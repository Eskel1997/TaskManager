using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Team
{
    public class TeamListItemModel
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public UserDisplayModel CreatedBy { get; set; }
        public int UsersCount { get; set; }
    }
}
