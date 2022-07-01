using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Queries.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class GetMyPermissionsHandler : IRequestHandler<GetMyPermissionsQuery, UserPermissionsModel>
    {
        private readonly IPermissionsService _permissionsService;
        public GetMyPermissionsHandler(
            IPermissionsService permissions)
        {
            _permissionsService = permissions;
        }
        public async Task<UserPermissionsModel> Handle(GetMyPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _permissionsService.GetUserPermissions(request.UserId);
        }
    }
}
