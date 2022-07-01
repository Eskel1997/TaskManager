using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Task;
using TASKMANAGER.INFRASTRUCTURE.Queries.Task;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Task
{
    public class GetTaskDetailsHandler : IRequestHandler<GetTaskDetailsQuery, TaskDetailsModel>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskDetailsHandler(
            ITaskRepository taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<TaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetQuery()
                .Include(p => p.Project)
                .SingleOrDefaultAsync(p => p.PublicId == request.PublicId, cancellationToken: cancellationToken);

            if(task == null)
                throw new TaskManagerException(ErrorCode.NotFound);

            var result = _mapper.Map<TaskDetailsModel>(task);
            return result;
        }
    }
}
