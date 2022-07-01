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
            return Unit.Value;
        }
    }
}
