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
            var task = await _taskRepository.GetByIdAsync(request.TaskId.ToString());
            var comment = new DB.Entities.Concrete.Comment(request.Comment, task.Id, request.UserId);

            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
