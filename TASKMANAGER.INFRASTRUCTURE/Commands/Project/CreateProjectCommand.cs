using MediatR;
using System;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Project
{
    public class CreateProjectCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public Guid TeamId { get; set; }
        public ProjectStatusEnum Status { get; set; }
    }
}
