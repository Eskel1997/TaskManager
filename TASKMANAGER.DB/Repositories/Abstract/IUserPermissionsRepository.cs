using System.Collections.Generic;
using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface IUserPermissionsRepository : IRepository<UserPermissions>
    {
        Task<List<UserPermissions>> GetUserPermissions(long userId);
        Task<bool> CheckUserPermissions(long userId, DB.Enums.Permissions permission);
    }
}
