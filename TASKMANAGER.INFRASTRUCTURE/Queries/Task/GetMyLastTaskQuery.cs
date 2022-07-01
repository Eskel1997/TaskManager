using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Task
{
    public class GetMyLastTaskQuery :IRequest<List<TaskListItemModel>>, IAuth
    {
        public long UserId { get; set; }
    }
}
