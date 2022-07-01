using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Commands.Project;
using TASKMANAGER.INFRASTRUCTURE.Queries.Project;

namespace TASKMANAGER.API.ViewModels.Project
{
    public class ProjectAutoMapper : Profile
    {
        public ProjectAutoMapper()
        {
            CreateMap<CreateProjectModel, CreateProjectCommand>();
            CreateMap<UpdateProjectModel, UpdateProjectCommand>();
            CreateMap<GetAllProjectsModel, GetAllProjectsQuery>();
            CreateMap<GetProjectDictionaryModel, GetProjectDictionaryQuery>();
        }
    }
}
