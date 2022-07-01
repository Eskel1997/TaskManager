using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Queries.Task;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Task
{
    public class GetMyLastTaskHandler : IRequestHandler<GetMyLastTaskQuery, List<TaskListItemModel>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public GetMyLastTaskHandler(
            ITaskRepository taskRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskListItemModel>> Handle(GetMyLastTaskQuery request, CancellationToken cancellationToken)
        {
            var list = await _taskRepository.GetQuery()
                .Include(p => p.Project)
                .Where(p => p.OwnerId == request.UserId || p.CreatedById == request.UserId)
                .OrderByDescending(p => p.CreatedAt)
                .Take(5)
                .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<List<TaskListItemModel>>(list);
        }
    }
}
