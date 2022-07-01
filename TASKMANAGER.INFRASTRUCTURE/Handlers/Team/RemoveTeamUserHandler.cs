using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class RemoveTeamUserHandler : IRequestHandler<RemoveTeamUserCommand, Unit>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeamUserRepository _teamUserRepository;

        public RemoveTeamUserHandler(ITeamRepository teamRepository,
            IUserRepository userRepository,
            ITeamUserRepository teamUserRepository)
        {
            _teamRepository = teamRepository;
            _userRepository = userRepository;
            _teamUserRepository = teamUserRepository;
        }

        public async Task<Unit> Handle(RemoveTeamUserCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
