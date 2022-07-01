using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Comment;
using TASKMANAGER.INFRASTRUCTURE.Queries.Comment;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Comment
{
    public class GetTaskCommentsHandler : IRequestHandler<GetTaskCommentsQuery, List<ListItemModel>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskCommentsHandler(
            ICommentRepository commentRepository,
            ITaskRepository taskRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }


        public async Task<List<ListItemModel>> Handle(GetTaskCommentsQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.TaskId.ToString());  
            if(task == null)
                throw new TaskManagerException(ErrorCode.NotFound);
            var list = _commentRepository.GetQuery()
                .Where(p => p.TaskId == task.Id);
            var results = _mapper.Map<IList<ListItemModel>>(await list.ToListAsync(cancellationToken: cancellationToken)).ToList();    
            return results;
        }
    }
}
