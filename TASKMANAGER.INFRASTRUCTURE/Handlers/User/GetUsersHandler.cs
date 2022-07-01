using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Extensions.User;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Queries.User;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserDisplayModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamUserRepository _teamUserRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GetUsersHandler(
            IUserRepository userRepository,
            ITeamRepository teamRepository,
            ITeamUserRepository teamUserRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _teamUserRepository = teamUserRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDisplayModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.TeamId.ToString());
            var list = new List<DB.Entities.Concrete.User>();
            if (team != null)
            {


                var userIds = await _teamUserRepository.GetUsersIdsAsync(team.Id);
                list = await _userRepository.GetQuery()
                    .Where(p => userIds.Contains(p.Id))
                    .FilterByName(request.Name)
                    .ToListAsync(cancellationToken: cancellationToken);
            }
            else
            {
                list = (List<DB.Entities.Concrete.User>)await _userRepository.GetQuery()
                    .FilterByName(request.Name)
                    .ToListAsync(cancellationToken: cancellationToken);
            }

            return _mapper.Map<List<UserDisplayModel>>(list);
        }
    }
}
