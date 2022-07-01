using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class _projectRepository : Repository<Project>, IProjectRepository
    {
        public _projectRepository(TaskManagerContext context) : base(context)
        {

        }

        public async Task<Project> GetByIdAsync(string id)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.PublicId.ToString() == id);
        }
    }
}
