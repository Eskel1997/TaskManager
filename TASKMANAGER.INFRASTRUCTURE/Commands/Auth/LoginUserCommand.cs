using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Auth
{
    public class LoginUserCommand : IRequest<TokenModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
