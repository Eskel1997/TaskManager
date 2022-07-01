using System.Collections.Generic;
using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface ITaskRepository : IRepository<Entities.Concrete.Task>
    {
        Task<Entities.Concrete.Task> GetByIdAsync(string id);
        Task<Entities.Concrete.Task> GetWithCommentsAsync(string id);
        void RemoveComments(List<Comment> comments);
    }
}
