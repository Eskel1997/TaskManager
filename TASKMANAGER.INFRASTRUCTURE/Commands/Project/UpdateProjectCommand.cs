using System;
using MediatR;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Project
{
    public class UpdateProjectCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public ProjectStatusEnum Status { get; set; }
    }
}
