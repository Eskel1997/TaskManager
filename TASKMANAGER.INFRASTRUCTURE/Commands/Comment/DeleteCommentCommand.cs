using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Comment
{
    public class DeleteCommentCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }
    }
}
