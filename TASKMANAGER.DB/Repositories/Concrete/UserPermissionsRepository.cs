using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class UserPermissionsRepository : Repository<UserPermissions>, IUserPermissionsRepository
    {
        public UserPermissionsRepository(TaskManagerContext context) : base(context)
        {
        }

        public async Task<List<UserPermissions>> GetUserPermissions(long userId)
        {
            return await DbSet.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<bool> CheckUserPermissions(long userId, DB.Enums.Permissions permission)
        {
            return await DbSet.Where(p => p.UserId == userId && p.Permission == permission.ToString()).CountAsync() > 0;
        }
    }
}
