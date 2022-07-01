using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Comment;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Comment
{
    public class CreateCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITaskRepository _taskRepository;

        public CreateCommandHandler(
            ICommentRepository commentRepository, 
            ITaskRepository taskRepository)
        {
            _commentRepository = commentRepository;
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
           
            return Unit.Value;
        }
    }
}
