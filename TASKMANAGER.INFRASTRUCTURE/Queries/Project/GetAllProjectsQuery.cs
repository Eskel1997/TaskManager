using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Project;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Project
{
    public class GetAllProjectsQuery : PaginatedList, IRequest<ProjectListModel>
    {
       public string Search { get; set; }
    }
}
