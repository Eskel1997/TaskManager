using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Task;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Task
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IPermissionsService _permissionsService; 

        public UpdateTaskHandler(
            IProjectRepository projectRepository,
            IUserRepository userRepository,
            ITaskRepository taskRepository,
            IPermissionsService permissions)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _permissionsService = permissions;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditTask)
                throw new TaskManagerException(ErrorCode.NoPermission);
            var project = await _projectRepository.GetByIdAsync(request.ProjectId.ToString());
            var user = (await _userRepository.GetByIdAsync(request.OwnerId.ToString()));
            var task = await _taskRepository.GetByIdAsync(request.PublicId.ToString());

            task.Update(request.Name, (int)request.Priority,
                request.Description, project.Id, user.Id, (int)request.Status);

            await _taskRepository.UpdateAsync(task);
            await _taskRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
