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
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditProject)
                throw new TaskManagerException(ErrorCode.NoPermission);

            var team = await _teamRepository.GetByIdAsync(request.TeamId.ToString());
            var project = await _projectRepository.GetByIdAsync(request.PublicId.ToString());

            project.Update(request.Name, request.Status, team.Id);

            await _projectRepository.UpdateAsync(project);
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
