using System.Linq;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> source, int pageNumber, int pageSize)
            where T : Entity
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
