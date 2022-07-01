using System.Threading.Tasks;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.INFRASTRUCTURE.Models.User;

namespace TASKMANAGER.INFRASTRUCTURE.Services.Abstract
{
    public interface IPermissionsService : IService
    {
        Task<UserPermissionsModel> GetUserPermissions(long userId);
        Task<UserPermissionsModel> UpdateUserPermissions(long userId, UserPermissionsModel permissions);
        Task<bool> CheckUserPermission(long userId, Permissions permissionEnum );
    }
}
