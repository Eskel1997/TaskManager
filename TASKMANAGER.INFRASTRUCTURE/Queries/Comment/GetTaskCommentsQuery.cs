using MediatR;
using System;
using System.Collections.Generic;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Comment;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Comment
{
    public class GetTaskCommentsQuery : PaginatedList, IRequest<List<ListItemModel>>
    {
        public Guid TaskId { get; set; }
    }
}
