using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Extensions;
using TASKMANAGER.DB.Extensions.Team;
using TASKMANAGER.DB.Helpers;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Team;
using TASKMANAGER.INFRASTRUCTURE.Queries.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, TeamListModel>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetAllTeamsHandler(ITeamRepository teamRepository,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<TeamListModel> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var list = _teamRepository.GetQuery()
                .Include(p => p.TeamUsers)
                .FilterByName(request.Search);

            var totalCount = await list.CountAsync(cancellationToken: cancellationToken);

            list.ApplyPagination(request.PageNumber, request.PageSize);

            var results =
                _mapper.Map<IList<TeamListItemModel>>(await list.ToListAsync(cancellationToken: cancellationToken));
            var paginationMetadata = new PaginationMetadata(request.PageNumber, request.PageSize, totalCount);

            return new TeamListModel()
            {
                Results = results,
                PaginationMetadata = paginationMetadata
            };
        }
    }
}
