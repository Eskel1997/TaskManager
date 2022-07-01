using MediatR;
using System.Collections.Generic;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Team
{
    public class GetTeamDictionaryQuery : IRequest<List<GenericKeyValuePair>>, IAuth
    {
        public long UserId { get; set; }
        public string Search { get; set; }
    }
}
