using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Task;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Task
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IPermissionsService _permissionsService;
        public CreateTaskHandler(
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

        public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditTask)
                throw new TaskManagerException(ErrorCode.NoPermission);

            var project = await _projectRepository.GetByIdAsync(request.ProjectId.ToString());
            var user = await _userRepository.GetByIdAsync(request.OwnerId.ToString());
            var userId = user?.Id ?? request.UserId;

            var task = new DB.Entities.Concrete.Task(request.Name, (int)request.Priority,
                request.Description, project.Id, request.UserId, userId, (int)request.Status);

            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
