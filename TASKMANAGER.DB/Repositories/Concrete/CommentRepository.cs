using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class _commentRepository : Repository<Comment>, ICommentRepository
    {
        public _commentRepository(TaskManagerContext context) : base(context)
        {

        }
        public async Task<Comment> GetByIdAsync(string id)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.PublicId.ToString() == id);
        }
    }
}
