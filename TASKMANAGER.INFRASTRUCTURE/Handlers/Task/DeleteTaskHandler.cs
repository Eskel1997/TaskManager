using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Task;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Task
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IPermissionsService _permissionsService;

        public DeleteTaskHandler(
            ITaskRepository taskRepository,
            IPermissionsService permissions)
        {
            _taskRepository = taskRepository;
            _permissionsService = permissions;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.PublicId.ToString());
            await _taskRepository.DeleteAsync(task);
            await _taskRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
