using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Extensions;
using TASKMANAGER.DB.Extensions.Project;
using TASKMANAGER.DB.Helpers;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Project;
using TASKMANAGER.INFRASTRUCTURE.Queries.Project;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Project
{
    public class GetAllProjectHandler : IRequestHandler<GetAllProjectsQuery, ProjectListModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetAllProjectHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectListModel> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var list = _projectRepository.GetQuery()
                .FilterByName(request.Search)
                .Include(p => p.Team);

            var totalCount = await list.CountAsync(cancellationToken: cancellationToken);

            list.ApplyPagination(request.PageNumber, request.PageSize);

            var results =
                _mapper.Map<IList<ProjectListItemModel>>(await list.ToListAsync(cancellationToken: cancellationToken));
            var paginationMetadata = new PaginationMetadata(request.PageNumber, request.PageSize, totalCount);

            return new ProjectListModel()
            {
                Results = results,
                PaginationMetadata = paginationMetadata
            };
        }
    }
}
