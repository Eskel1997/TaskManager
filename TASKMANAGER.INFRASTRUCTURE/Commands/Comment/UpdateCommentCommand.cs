using MediatR;
using System;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Comment
{
    public class UpdateCommentCommand : IRequest, IAuth
    {
        public long UserId { get; set; }
        public Guid PublicId { get; set; }
        public string Comment {get ; set; }
    }
}
