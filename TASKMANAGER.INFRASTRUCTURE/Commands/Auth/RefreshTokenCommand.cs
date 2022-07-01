using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.Auth
{
    public class RefreshTokenCommand : IRequest<TokenModel>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
