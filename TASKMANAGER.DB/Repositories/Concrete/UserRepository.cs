using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class _userRepository : Repository<User>, IUserRepository
    {
        public _userRepository(TaskManagerContext context) : base(context)
        {

        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.PublicId.ToString() == id);
        }

        public User GetById(long id)
        {
            return DbSet.SingleOrDefault(u => u.Id == id);
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return  await DbSet.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
