using Castle.Core.Internal;
using System.Linq;

namespace TASKMANAGER.DB.Extensions.User
{
    public static class UserExtensions
    {
        public static IQueryable<Entities.Concrete.User> FilterByName(this IQueryable<Entities.Concrete.User> users,
            string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return users.Where(p => p.Name.ToLower().Contains(name.ToLower())
                                        || p.LastName.ToLower().Contains(name.ToLower()));
            }

            return users;
        }
    }
}
