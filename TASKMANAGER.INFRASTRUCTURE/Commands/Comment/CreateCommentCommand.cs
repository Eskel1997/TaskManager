using System;
using MediatR;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Comment
{
    public class CreateCommentCommand : IRequest, IAuth
    {
        public Guid TaskId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; }
    }
}
