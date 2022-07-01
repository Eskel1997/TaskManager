using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Commands.Task;
using TASKMANAGER.INFRASTRUCTURE.Queries.Task;

namespace TASKMANAGER.API.ViewModels.Task
{
    public class TaskAutoMapper : Profile
    {
        public TaskAutoMapper()
        {
            CreateMap<CreateTaskModel, CreateTaskCommand>();
            CreateMap<UpdateTaskModel, UpdateTaskCommand>();
            CreateMap<GetAllTaskModel, GetAllTaskQuery>();
        }
    }
}
