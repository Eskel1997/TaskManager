using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.INFRASTRUCTURE.Services.Abstract
{
    public interface IUserService : IService
    {
        Task<User> RegisterUserAsync(string name, string pictureUrl, string lastName, string username, string email, string password);

        System.Threading.Tasks.Task ChangeUserPassword(long userId, string oldPassword, string newPassword);
    }
}
