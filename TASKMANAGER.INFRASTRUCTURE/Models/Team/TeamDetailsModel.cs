using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Team
{
    public class TeamDetailsModel
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public UserDisplayModel CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UsersCount { get; set; }
        public int ProjectsCount { get; set; }
    }
}
