using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models.Team;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Team
{
    public class GetTeamDetailsQuery : IRequest<TeamDetailsModel>
    {
        public Guid PublicId { get; set; }

        public GetTeamDetailsQuery(Guid publicId)
        {
            PublicId = publicId;
        }
    }
}
