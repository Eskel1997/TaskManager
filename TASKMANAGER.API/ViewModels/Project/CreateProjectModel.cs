using System;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.API.ViewModels.Project
{
    public class CreateProjectModel
    {
        public string Name { get; set; }
        public Guid TeamId { get; set; }
        public ProjectStatusEnum Status { get; set; }
    }
}
