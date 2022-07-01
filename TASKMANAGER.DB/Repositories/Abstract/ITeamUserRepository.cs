using System.Collections.Generic;
using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface ITeamUserRepository : IRepository<UserTeam>
    {
        Task<List<long>> GetUsersIdsAsync(long publicId);
        Task<List<UserTeam>> GetTeamUsersAsync(long teamId);
        Task<UserTeam> GetTeamUserAsync(long teamId, long userId);
        System.Threading.Tasks.Task RemoveTeamUsersAsync(List<UserTeam> teamUsers);
    }
}
