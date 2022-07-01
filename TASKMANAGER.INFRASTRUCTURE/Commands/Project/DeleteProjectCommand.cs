using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Project
{
    public class DeleteProjectCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }

        public DeleteProjectCommand(Guid publicId)
        {
            PublicId = publicId;
        }
    }
}
