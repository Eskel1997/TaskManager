using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TASKMANAGER.INFRASTRUCTURE.Models.User;

namespace TASKMANAGER.INFRASTRUCTURE.Queries.User
{
    public class GetUserPermissionsQuery : IRequest<UserPermissionsModel>, IAuth
    {
        public string PublicId {get; set;}
        public long UserId {get; set;}

        public GetUserPermissionsQuery(string publicId)
        {
            PublicId = publicId;
        }
    }
}
