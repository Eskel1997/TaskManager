using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetByIdAsync(string id);
    }
}
