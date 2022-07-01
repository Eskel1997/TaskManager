using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Task
{
    public class DeleteTaskCommand : IRequest, IAuth
    {
        public Guid PublicId { get; set; }
        public long UserId { get; set; }

        public DeleteTaskCommand(Guid publicId)
        {
            PublicId = publicId;
        }
    }
}
