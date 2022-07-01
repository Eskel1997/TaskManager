using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Comment;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Comment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
