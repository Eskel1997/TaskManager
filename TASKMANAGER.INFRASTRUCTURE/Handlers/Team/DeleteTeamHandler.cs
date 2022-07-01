﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand, Unit>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPermissionsService _permissionsService;
        private readonly ITeamUserRepository _teamUserRepository;
        public DeleteTeamHandler(
            ITeamRepository teamRepository,
            IPermissionsService permissions,
            ITeamUserRepository teamUserRepository)
        {
            _teamRepository = teamRepository;
            _permissionsService = permissions;
            _teamUserRepository = teamUserRepository;
        }

        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
