using System;
using System.Collections.Generic;
using System.Text;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class UserPermissions : Entity
    {
        public long UserId {get; protected set;}
        public string Permission {get; protected set;}
        public DateTime CreatedAt {get; protected set;}
        public virtual User User {get; protected set; }

        public UserPermissions() {}
        public UserPermissions(long userId, string permission)
        {
            CreatedAt = DateTime.UtcNow;
            ChangeUser(userId);
            ChangeUserPermission(permission);
        }


        private void ChangeUser(long userId)
        {
            UserId = userId;
        }

        private void ChangeUserPermission(string permission)
        {
            Permission = permission; 
        }
    }
}
