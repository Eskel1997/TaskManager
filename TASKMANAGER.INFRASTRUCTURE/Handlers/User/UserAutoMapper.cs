using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<DB.Entities.Concrete.User, GenericKeyValuePair>()
                .ForMember(p => p.Key, o => o.MapFrom(s => s.PublicId))
                .ForMember(p => p.Value, o => o.MapFrom(s => s.Username));
        }
    }
}
