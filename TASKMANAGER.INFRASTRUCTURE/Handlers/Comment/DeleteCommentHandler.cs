using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Comment;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Comment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.PublicId.ToString());
            if (comment.CreatedById != request.UserId)
                throw new TaskManagerException(ErrorCode.NoPermission);

            await _commentRepository.DeleteAsync(comment);
            await _commentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
