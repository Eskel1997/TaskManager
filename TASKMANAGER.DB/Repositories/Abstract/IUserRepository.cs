using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(long id);
        User GetById(long id);
    }
}
