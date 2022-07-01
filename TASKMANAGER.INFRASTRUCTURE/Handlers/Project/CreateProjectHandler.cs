using System.Threading;
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
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditProject)
                throw new TaskManagerException(ErrorCode.NoPermission);

            var team = await _teamRepository.GetByIdAsync(request.TeamId.ToString());
            var project = new DB.Entities.Concrete.Project(request.Name, request.Status, team.Id);
            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
