using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.User
{
    public class GetUserDictionaryQuery : IRequest<List<GenericKeyValuePair>>
    {
        public GetUserDictionaryQuery()
        {
            
        }
    }
}
