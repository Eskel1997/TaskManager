using Castle.Core.Internal;
using System.Linq;

namespace TASKMANAGER.DB.Extensions.Task
{
    public static class TaskExtensions
    {
        public static IQueryable<Entities.Concrete.Task> FilterByName(this IQueryable<Entities.Concrete.Task> tasks,
            string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return tasks.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            return tasks;
        }

        public static IQueryable<Entities.Concrete.Task> FilterByUser(this IQueryable<Entities.Concrete.Task> tasks,
            long? id)
        {
            if (id != null && id > 0)
            {
                return tasks.Where(p => p.OwnerId == id);
            }

            return tasks;
        }

        public static IQueryable<Entities.Concrete.Task> FilterByProject(
            this IQueryable<Entities.Concrete.Task> tasks, long? projectId)
        {
            if (projectId != null && projectId > 0)
            {
                return tasks.Where(p => p.ProjectId == projectId);
            }

            return tasks;
        }


    }
}
