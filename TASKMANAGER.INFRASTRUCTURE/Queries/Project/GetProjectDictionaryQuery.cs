using MediatR;
using System.Collections.Generic;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.Project
{
    public class GetProjectDictionaryQuery : IRequest<List<GenericKeyValuePair>>
    {
        public string Search { get; set; }
    }
}
