using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Team;
using TASKMANAGER.INFRASTRUCTURE.Queries.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class GetTeamDetailsHandler : IRequestHandler<GetTeamDetailsQuery, TeamDetailsModel>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GetTeamDetailsHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<TeamDetailsModel> Handle(GetTeamDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _teamRepository.GetQuery()
                .Include(p => p.TeamUsers)
                .Include(p => p.Projects)
                .SingleOrDefaultAsync(p => p.PublicId == request.PublicId, cancellationToken: cancellationToken);
            if (result == null)
            {
                throw new TaskManagerException(ErrorCode.NotFound);
            }

            return _mapper.Map<TeamDetailsModel>(result);
        }
    }
}
