using System;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.API.ViewModels.Task
{
    public class CreateTaskModel
    {
        public string Name { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Guid ProjectId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
