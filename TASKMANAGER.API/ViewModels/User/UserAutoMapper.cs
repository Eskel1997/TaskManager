using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;
using TASKMANAGER.INFRASTRUCTURE.Queries.User;

namespace TASKMANAGER.API.ViewModels.User
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserFilterModel, GetUsersQuery>();
            CreateMap<ChangePasswordModel, ChangePasswordCommand>();
            CreateMap<EditPictureModel, EditPictureCommand>();
        }
    }
}
