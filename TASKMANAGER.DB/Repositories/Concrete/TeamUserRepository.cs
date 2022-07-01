using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class _teamUserRepository : Repository<UserTeam>, ITeamUserRepository
    {
        public _teamUserRepository(TaskManagerContext context) : base(context)
        {
        }

        public async Task<List<long>> GetUsersIdsAsync(long teamId)
        { 
            return await Context.TeamUsers
                .Where(p => p.TeamId == teamId).Select(s => s.UserId).ToListAsync();
        }

        public async Task<List<UserTeam>> GetTeamUsersAsync(long teamId)
        {
            return await Context.TeamUsers.Where(p => p.TeamId == teamId).ToListAsync();
        }

        public async Task<UserTeam> GetTeamUserAsync(long teamId, long userId)
        {
            return await Context.TeamUsers
                .FirstOrDefaultAsync(p => p.TeamId == teamId && p.UserId == userId);
        }

        public async System.Threading.Tasks.Task RemoveTeamUsersAsync(List<UserTeam> teamUsers)
        {
            Context.RemoveRange(teamUsers);
        }
    }
}
