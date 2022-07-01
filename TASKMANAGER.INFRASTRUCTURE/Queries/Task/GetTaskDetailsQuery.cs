using MediatR;
using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Task;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Task
{
    public class GetTaskDetailsQuery : IRequest<TaskDetailsModel>, IAuth
    {
        public long UserId {get; set; }
        public Guid PublicId { get; set; }

        public GetTaskDetailsQuery(Guid publicId)
        {
            PublicId = publicId;
        }
    }
}
