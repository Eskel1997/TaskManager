using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models.User
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<DB.Entities.Concrete.User, UserDisplayModel>();
        }
    }
}
