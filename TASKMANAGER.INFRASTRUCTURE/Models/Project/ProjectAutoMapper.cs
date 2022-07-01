using System;
using AutoMapper;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Project
{
    public class ProjectAutoMapper : Profile
    {
        public ProjectAutoMapper()
        {
            CreateMap<DB.Entities.Concrete.Project, GenericKeyValuePair>()
                .ForMember(p => p.Key, o => o.MapFrom(s => s.PublicId))
                .ForMember(p => p.Value, o => o.MapFrom(s => s.Name));

            CreateMap<DB.Entities.Concrete.Project, ProjectListItemModel>()
                .ForMember(p => p.Status, o 
                    => o.MapFrom(s => new GenericKeyValuePair(s.Status.ToString(), Enum.GetName(typeof(ProjectStatusEnum),s.Status))));

            CreateMap<DB.Entities.Concrete.Project, ProjectDetailsModel>()
                .ForMember(p => p.Status, o 
                    => o.MapFrom(s => new GenericKeyValuePair(s.Status.ToString(), Enum.GetName(typeof(ProjectStatusEnum),s.Status))))
                .ForMember(p => p.Team, o => o.MapFrom(s => s.Team));


        }
    }
}
