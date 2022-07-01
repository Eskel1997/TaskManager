﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Project;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Project
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPermissionsService _permissionsService;
        public CreateProjectHandler(
            IProjectRepository projectRepository,
            ITeamRepository teamRepository,
            IPermissionsService permissionsService)
        {
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _permissionsService = permissionsService;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
