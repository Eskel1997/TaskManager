using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models.Comment;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.User
{
    public class GetUsersQuery : IRequest<List<UserDisplayModel>>
    {
        public Guid? TeamId { get; set; }
        public string Name { get; set; }
    }
}
