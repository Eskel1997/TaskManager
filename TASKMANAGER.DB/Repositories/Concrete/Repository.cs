using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.DB.Entities.Abstract;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.DB.Repositories.Concrete
{
    internal class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TaskManagerContext Context;
        protected readonly DbSet<T> DbSet;
        public Repository(TaskManagerContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
           return await DbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Task.FromResult(DbSet.Add(entity));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.FromResult(DbSet.Remove(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.FromResult(DbSet.Update(entity));
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public IQueryable<T> GetQuery()
        {
            return DbSet;
        }
    }
}
