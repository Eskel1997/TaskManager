using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.User
{
    public class RegisterCommand : IRequest<TokenModel>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username {get ; set; }
        public string Email {get ; set; }
        public string Password {get ; set; }
    }
}
