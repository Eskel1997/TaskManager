using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    internal class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly IUserService _userService;
        public ChangePasswordHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await _userService.ChangeUserPassword(request.UserId, request.OldPassword,request.NewPassword);
            return Unit.Value;
        }
    }
}
