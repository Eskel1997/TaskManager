using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, Unit>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPermissionsService _permissionsService;
        public CreateTeamHandler(
            ITeamRepository teamRepository,
            IPermissionsService permissionsService)
        {
            _teamRepository = teamRepository;
            _permissionsService = permissionsService;
        }

        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditTeam)
                throw new TaskManagerException(ErrorCode.NoPermission);

            var team = new DB.Entities.Concrete.Team(request.Name, request.UserId);

            await _teamRepository.AddAsync(team);
            await _teamRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
