using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class AddTeamUserHandler : IRequestHandler<AddTeamUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamUserRepository _teamUserRepository;

        public AddTeamUserHandler(IUserRepository userRepository,
            ITeamRepository teamRepository,
            ITeamUserRepository teamUserRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _teamUserRepository = teamUserRepository;
        }
        public async Task<Unit> Handle(AddTeamUserCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.PublicId.ToString());
            var user = await _userRepository.GetByIdAsync(request.TeamUserId.ToString());
            var teamUser = new UserTeam(user.Id, team.Id, request.UserId);
            await _teamUserRepository.AddAsync(teamUser);
            await _teamUserRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
