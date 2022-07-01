using System;
using AutoMapper;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Resolvers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Task
{
    public class TaskAutoMapper : Profile
    {
        public TaskAutoMapper()
        {
            CreateMap<DB.Entities.Concrete.Task, GenericKeyValuePair>()
                .ForMember(p => p.Key, o => o.MapFrom(s => s.PublicId))
                .ForMember(p => p.Value, o => o.MapFrom(s => s.Name));

            CreateMap<DB.Entities.Concrete.Task, TaskListItemModel>()
                .ForMember(p => p.CreatedBy, o => o.MapFrom<UserResolver, long?>(s => s.CreatedById))
                .ForMember(p => p.Owner, o => o.MapFrom<UserResolver, long?>(s => s.OwnerId))
                .ForMember(p => p.Status, o => o.MapFrom(s => new GenericKeyValuePair(s.Status.ToString(), Enum.GetName(typeof(TaskStatusEnum), s.Status))))
                .ForMember(p => p.Priority, o => o.MapFrom(s => new GenericKeyValuePair(s.Priority.ToString(), Enum.GetName(typeof(TaskPriorityEnum), s.Priority))));

            CreateMap<DB.Entities.Concrete.Task, TaskDetailsModel>()
                .ForMember(p => p.CreatedBy, o => o.MapFrom<UserResolver, long?>(s => s.CreatedById))
                .ForMember(p => p.Owner, o => o.MapFrom<UserResolver, long?>(s => s.OwnerId))
                .ForMember(p => p.Status,
                    o => o.MapFrom(s =>
                        new GenericKeyValuePair(s.Status.ToString(), Enum.GetName(typeof(TaskStatusEnum), s.Status))))
                .ForMember(p => p.Priority,
                    o => o.MapFrom(s =>
                        new GenericKeyValuePair(s.Priority.ToString(),
                            Enum.GetName(typeof(TaskPriorityEnum), s.Priority))))
                .ForMember(p => p.Project,
                    o => o.MapFrom(s => new GenericKeyValuePair(s.Project.PublicId.ToString(), s.Project.Name)));

        }
    }
}
