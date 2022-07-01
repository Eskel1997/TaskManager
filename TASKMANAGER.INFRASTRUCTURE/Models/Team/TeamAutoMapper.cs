using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Resolvers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Team
{
    public class TeamAutoMapper : Profile
    {
        public TeamAutoMapper()
        {
            CreateMap<DB.Entities.Concrete.Team, GenericKeyValuePair>()
                .ForMember(p => p.Key, o => o.MapFrom(s => s.PublicId))
                .ForMember(p => p.Value, o => o.MapFrom(s => s.Name));

            CreateMap<DB.Entities.Concrete.Team, TeamListItemModel>()
                .ForMember(p => p.CreatedBy, o => o.MapFrom<UserResolver, long?>(s => s.CreatedById))
                .ForMember(p => p.UsersCount, o => o.MapFrom(s => s.TeamUsers.Count));

            CreateMap<DB.Entities.Concrete.Team, TeamDetailsModel>()
                .ForMember(p => p.CreatedBy, o => o.MapFrom<UserResolver, long?>(s => s.CreatedById))
                .ForMember(p => p.UsersCount, o => o.MapFrom(s => s.TeamUsers.Count))
                .ForMember(p => p.ProjectsCount, o => o.MapFrom(s => s.Projects.Count));
        }
    }
}
