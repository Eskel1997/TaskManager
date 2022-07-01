using Castle.Core.Internal;
using System.Linq;

namespace TASKMANAGER.DB.Extensions.Team
{
    public static class TeamExtensions
    {
        public static IQueryable<Entities.Concrete.Team> FilterByName(this IQueryable<Entities.Concrete.Team> teams,
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
