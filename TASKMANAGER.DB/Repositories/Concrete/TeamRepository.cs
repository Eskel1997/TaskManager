using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class _teamRepository : Repository<Team>, ITeamRepository
    {
        public _teamRepository(TaskManagerContext context) : base(context)
        {

        }

        public async Task<Team> GetByIdAsync(string id)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.PublicId.ToString() == id);
        }

        public void RemoveUsers(List<UserTeam> users)
        {
            Context.RemoveRange(users);
        }
    }
}
