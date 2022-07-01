using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Repositories.Abstract
{
    public interface IRepository<T> : IRepository where T : Entity
    {
        Task<T> GetByIdAsync(long id);
        Task<IList<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();
        IQueryable<T> GetQuery();
    }
    public interface IRepository {}
}
