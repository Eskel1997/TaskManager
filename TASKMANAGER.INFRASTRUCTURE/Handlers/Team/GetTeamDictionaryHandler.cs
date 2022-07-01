using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Queries.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class GetTeamDictionaryHandler : IRequestHandler<GetTeamDictionaryQuery, List<GenericKeyValuePair>>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetTeamDictionaryHandler(
            ITeamRepository teamRepository,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<List<GenericKeyValuePair>> Handle(GetTeamDictionaryQuery request, CancellationToken cancellationToken)
        {
            var list = _teamRepository.GetQuery();

            if (!string.IsNullOrEmpty(request.Search))
                list = list.Where(p => p.Name.ToLower().Contains(request.Search.ToLower()));

            return _mapper.Map<List<GenericKeyValuePair>>(await list.ToListAsync(cancellationToken: cancellationToken));
        }
    }
}
