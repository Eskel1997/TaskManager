using AutoMapper;
using TASKMANAGER.API.Validators.Team;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;
using TASKMANAGER.INFRASTRUCTURE.Queries.Team;

namespace TASKMANAGER.API.ViewModels.Team
{
    public class TeamAutoMapper : Profile
    {
        public TeamAutoMapper()
        {
            CreateMap<CreateTeamModel, CreateTeamCommand>();
            CreateMap<UpdateTeamModel, UpdateTeamCommand>();
            CreateMap<GetAllTeamsModel, GetAllTeamsQuery>();
            CreateMap<GetTeamDictionaryModel, GetTeamDictionaryQuery>();
        }
    }
}
