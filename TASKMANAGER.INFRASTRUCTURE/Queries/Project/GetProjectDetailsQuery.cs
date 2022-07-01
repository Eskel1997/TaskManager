using MediatR;
using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Project;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Project
{
    public class GetProjectDetailsQuery : IRequest<ProjectDetailsModel>
    {
        public Guid PublicId { get; set; }
        public GetProjectDetailsQuery(Guid publicId)
        {
            PublicId = publicId;
        }
    }
}
