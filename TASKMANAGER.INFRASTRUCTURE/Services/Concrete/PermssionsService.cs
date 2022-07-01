using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Services.Concrete
{
    internal class PermssionsService : IPermissionsService
    {
        private readonly IUserPermissionsRepository _permissionsRepository;
        public PermssionsService(
            IUserPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }
        public async Task<bool> CheckUserPermission(long userId, Permissions permissionEnum)
        {
            return await _permissionsRepository.CheckUserPermissions(userId, permissionEnum);
        }

        public async Task<UserPermissionsModel> GetUserPermissions(long userId)
        {
            var userPermissions = await _permissionsRepository.GetUserPermissions(userId);

            var result = CheckPermissions(userPermissions);

            return result;

        }

        public async Task<UserPermissionsModel> UpdateUserPermissions(long userId, UserPermissionsModel permissions)
        {
            var userPermissions = await _permissionsRepository.GetUserPermissions(userId);
            var dbPermissionsModel = CheckPermissions(userPermissions);
            await UpdatePermissions(userId, userPermissions, dbPermissionsModel, permissions);
            var newPermissions = await _permissionsRepository.GetUserPermissions(userId);
            return CheckPermissions(newPermissions);
        }

        private UserPermissionsModel CheckPermissions(List<DB.Entities.Concrete.UserPermissions> permissions)
        {
            var permissionModel = new UserPermissionsModel();
            
            if(permissions.FirstOrDefault(p => p.Permission == nameof(Permissions.SuperAdmin)) != null)
            {
                permissionModel.SuperAdmin = true;
            }
            else
                permissionModel.SuperAdmin = false;

            if(permissions.FirstOrDefault(p => p.Permission == nameof(Permissions.CanAddEditProject)) != null)
                permissionModel.CanAddEditProject = true;
            else
                permissionModel.CanAddEditProject = false;

            if(permissions.FirstOrDefault(p => p.Permission == nameof(Permissions.CanAddEditTask)) != null)
                permissionModel.CanAddEditTask = true;
            else
                permissionModel.CanAddEditTask = false;

            if(permissions.FirstOrDefault(p => p.Permission == nameof(Permissions.CanAddEditTeam)) != null)
                permissionModel.CanAddEditTeam = true;
            else
                permissionModel.CanAddEditTeam = false;


            return permissionModel;
        }

        private async Task UpdatePermissions(long userId, List<DB.Entities.Concrete.UserPermissions> dbPermissions, UserPermissionsModel actualPermissions, UserPermissionsModel requestedPermissions)
        {
            if(actualPermissions.SuperAdmin != requestedPermissions.SuperAdmin)
            {
                if(requestedPermissions.SuperAdmin)
                {
                    var item = new DB.Entities.Concrete.UserPermissions(userId, nameof(Permissions.SuperAdmin));
                    await _permissionsRepository.AddAsync(item);
                }
                else
                {
                    var item = dbPermissions.FirstOrDefault(p => p.Permission == nameof(Permissions.SuperAdmin));
                    await _permissionsRepository.DeleteAsync(item);
                }
                await _permissionsRepository.SaveChangesAsync();
            }

            if(actualPermissions.CanAddEditProject != requestedPermissions.CanAddEditProject)
            {
                if(requestedPermissions.CanAddEditProject)
                {
                    var item = new DB.Entities.Concrete.UserPermissions(userId, nameof(Permissions.CanAddEditProject));
                    await _permissionsRepository.AddAsync(item);
                }
                else
                {
                    var item = dbPermissions.FirstOrDefault(p => p.Permission == nameof(Permissions.CanAddEditProject));
                    await _permissionsRepository.DeleteAsync(item);
                }
                await _permissionsRepository.SaveChangesAsync();
            }

            if(actualPermissions.CanAddEditTask != requestedPermissions.CanAddEditTask)
            {
                if(requestedPermissions.CanAddEditTask)
                {
                    var item = new DB.Entities.Concrete.UserPermissions(userId, nameof(Permissions.CanAddEditTask));
                    await _permissionsRepository.AddAsync(item);
                }
                else
                {
                    var item = dbPermissions.FirstOrDefault(p => p.Permission == nameof(Permissions.CanAddEditTask));
                    await _permissionsRepository.DeleteAsync(item);
                }
                await _permissionsRepository.SaveChangesAsync();
            }

            if(actualPermissions.CanAddEditTeam != requestedPermissions.CanAddEditTeam)
            {
                if(requestedPermissions.CanAddEditTeam)
                {
                    var item = new DB.Entities.Concrete.UserPermissions(userId, nameof(Permissions.CanAddEditTeam));
                    await _permissionsRepository.AddAsync(item);
                }
                else
                {
                    var item = dbPermissions.FirstOrDefault(p => p.Permission == nameof(Permissions.CanAddEditTeam));
                    await _permissionsRepository.DeleteAsync(item);
                }
                await _permissionsRepository.SaveChangesAsync();
            }
        }
    }
}
