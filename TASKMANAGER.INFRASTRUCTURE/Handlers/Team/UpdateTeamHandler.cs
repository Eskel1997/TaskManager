using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Team
{
    public class UpdateTeamHandler : IRequestHandler<UpdateTeamCommand, Unit>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPermissionsService _permissionsService;
        public UpdateTeamHandler(
            ITeamRepository teamRepository,
            IPermissionsService permissionsService)
        {
            _teamRepository = teamRepository;
            _permissionsService = permissionsService;
        }

        public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var userPermissions = await _permissionsService.GetUserPermissions(request.UserId);
            if (!userPermissions.SuperAdmin && !userPermissions.CanAddEditTeam)
                throw new TaskManagerException(ErrorCode.NoPermission);

            var team = await _teamRepository.GetByIdAsync(request.PublicId.ToString());

            team.ChangeName(request.Name);
            await _teamRepository.UpdateAsync(team);
            await _teamRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
