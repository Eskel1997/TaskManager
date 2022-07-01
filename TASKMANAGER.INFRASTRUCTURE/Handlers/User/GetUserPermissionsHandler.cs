using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Queries.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class GetUserPermissionsHandler : IRequestHandler<GetUserPermissionsQuery, UserPermissionsModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPermissionsService _permissionsService;

        public GetUserPermissionsHandler(
            IUserRepository userRepository,
            IPermissionsService permissionsService)
        {
            _userRepository = userRepository;
            _permissionsService = permissionsService;
        }
        public async Task<UserPermissionsModel> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.PublicId);
            return await _permissionsService.GetUserPermissions(user.Id);
        }
    }
}
