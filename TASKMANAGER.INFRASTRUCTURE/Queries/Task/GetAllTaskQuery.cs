using System;
using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Task;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Task
{
    public class GetAllTaskQuery : PaginatedList, IRequest<TaskListModel>
    {
       public string Search { get; set; }
       public Guid? Project {get ; set; }
       public Guid? User { get; set; }
    }
}
