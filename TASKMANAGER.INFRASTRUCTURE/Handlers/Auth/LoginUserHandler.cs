using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Commands.Auth;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Auth
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, TokenModel>
    {
        private readonly IAuthService _authService;

        public LoginUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.LoginUserAsync(request.Email, request.Password);
        }
    }
}
