using Castle.Core.Internal;
using System.Linq;

namespace TASKMANAGER.DB.Extensions.Project
{
    public static class ProjectExtensions
    {
        public static IQueryable<Entities.Concrete.Project> FilterByName(this IQueryable<Entities.Concrete.Project> teams,
            string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return teams.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            return teams;
        }
    }
}
