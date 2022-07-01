using MediatR;
using System;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Task
{
    public class UpdateTaskCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Guid PublicId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
