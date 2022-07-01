using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, TokenModel>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public RegisterHandler(
            IUserService userService,
            IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        public async Task<TokenModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _userService.RegisterUserAsync(request.Name, "", request.LastName, request.Username, request.Email,
                request.Password);

            return await _authService.LoginUserAsync(request.Email, request.Password);
        }
    }
}
