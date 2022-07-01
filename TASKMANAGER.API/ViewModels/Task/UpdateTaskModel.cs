using System;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.API.ViewModels.Task
{
    public class UpdateTaskModel
    {
        public string Name { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Guid PublicId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
