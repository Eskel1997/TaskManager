using System;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.API.ViewModels.Project
{
    public class UpdateProjectModel
    {
        public Guid PublicId { get; set; }
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public ProjectStatusEnum Status { get; set; }
    }
}
