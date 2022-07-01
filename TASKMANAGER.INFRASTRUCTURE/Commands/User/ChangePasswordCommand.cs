using MediatR;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.User
{
    public class ChangePasswordCommand : IRequest, IAuth
    {
        public string OldPassword {get; set;}
        public string NewPassword {get ;set;}
        public string RepeatedPassword {get; set;}
        public long UserId {get; set; }
    }
}
