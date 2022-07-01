using System.Collections.Generic;
using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetByIdAsync(string id);
        void RemoveUsers(List<UserTeam> users);
    }
}
