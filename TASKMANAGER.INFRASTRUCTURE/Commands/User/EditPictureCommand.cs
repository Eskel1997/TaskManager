using MediatR;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.User
{
    public class EditPictureCommand : IRequest, IAuth
    {
        public string PictureUrl {get; set;}
        public long UserId {get; set;}
    }
}
