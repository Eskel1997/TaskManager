using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Project;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Project
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPermissionsService _permissionsService;

        public DeleteProjectHandler(
            IProjectRepository projectRepository,
            IPermissionsService permissionsService)
        {
            _projectRepository = projectRepository;
            _permissionsService = permissionsService;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditProject)
                throw new TaskManagerException(ErrorCode.NoPermission);

            var project = await _projectRepository.GetByIdAsync(request.PublicId.ToString());

            await _projectRepository.DeleteAsync(project);
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
