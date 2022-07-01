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
            return Unit.Value;
        }
    }
}
