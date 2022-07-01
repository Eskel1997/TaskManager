using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Project;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Project
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPermissionsService _permissionsService;
        public UpdateProjectHandler(
            IProjectRepository projectRepository,
            ITeamRepository teamRepository,
            IPermissionsService permissions)
        {
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _permissionsService = permissions;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
