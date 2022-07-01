using Moq;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mock
{
    internal static class MockPermissionService
    {
        public static Mock<IPermissionsService> GetPermissionService()
        {
            var withoutPermissionsModel = new UserPermissionsModel()
            {
                CanAddEditProject = false,
                CanAddEditTask = false,
                CanAddEditTeam = false,
                SuperAdmin = false,
            };

            var superAdminPermissions = new UserPermissionsModel()
            {
                CanAddEditProject = true,
                CanAddEditTask = true,
                CanAddEditTeam = true,
                SuperAdmin = true,
            };

            var mockSer = new Mock<IPermissionsService>();



            mockSer.Setup(r => r.GetUserPermissions(It.Is<long>(g => g == 1)))
                .ReturnsAsync(superAdminPermissions);

            mockSer.Setup(r => r.GetUserPermissions(It.Is<long>(g => g == 2)))
                .ReturnsAsync(withoutPermissionsModel);

            mockSer.Setup(r => r.UpdateUserPermissions(It.IsAny<long>(), It.IsAny<UserPermissionsModel>()))
                .ReturnsAsync(superAdminPermissions);

            mockSer.Setup(r => r.CheckUserPermission(It.IsAny<long>(), It.IsAny<Permissions>()))
                .ReturnsAsync(true);

            return mockSer;
        }
    }
}
