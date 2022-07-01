using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Extensions;
using TASKMANAGER.DB.Extensions.Task;
using TASKMANAGER.DB.Helpers;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Task;
using TASKMANAGER.INFRASTRUCTURE.Queries.Task;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Task
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, TaskListModel>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllTaskHandler(
            ITaskRepository taskRepository,
            ITeamRepository teamRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _teamRepository = teamRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TaskListModel> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.Project.ToString());
            var user = await _userRepository.GetByIdAsync(request.User.ToString());
            var list = _taskRepository.GetQuery()
                .Include(p => p.Project)
                .FilterByUser(user?.Id)
                .FilterByName(request.Search)
                .FilterByProject(team?.Id)
                .AsQueryable();

            var totalCount = await list.CountAsync(cancellationToken: cancellationToken);

            list.ApplyPagination(request.PageNumber, request.PageSize);

            var results =
                _mapper.Map<IList<TaskListItemModel>>(await list.ToListAsync(cancellationToken: cancellationToken));
            var paginationMetadata = new PaginationMetadata(request.PageNumber, request.PageSize, totalCount);

            return new TaskListModel()
            {
                Results = results,
                PaginationMetadata = paginationMetadata
            };
        }
    }
}
