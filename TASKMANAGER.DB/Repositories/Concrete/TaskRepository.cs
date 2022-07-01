using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class _taskRepository : Repository<Entities.Concrete.Task>, ITaskRepository
    {
        public _taskRepository(TaskManagerContext context) : base(context)
        {

        }
        public async Task<Entities.Concrete.Task> GetByIdAsync(string id)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.PublicId.ToString() == id);
        }

        public async Task<Entities.Concrete.Task> GetWithCommentsAsync(string id)
        {
            return await DbSet.Include(p => p.Comments).SingleOrDefaultAsync(u => u.PublicId.ToString() == id);
        }

        public void RemoveComments(List<Comment> comments)
        {
            Context.RemoveRange(comments);
        }
    }
}
