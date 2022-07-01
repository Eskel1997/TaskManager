using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface ICommentRepository: IRepository<Comment>
    {
        Task<Comment> GetByIdAsync(string id);
    }
}
