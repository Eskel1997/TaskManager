using Moq;
using System.Collections.Generic;
using System.Linq;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mocks
{
    internal static class MockTeamUserRepository
    {
        public static Mock<ITeamUserRepository> GetTeamUserRepository()
        {
            var teamUserList = new List<UserTeam>()
            {
                new UserTeam(1,1,1),
                new UserTeam(2,2,2),
                new UserTeam(3,3,3)
            };

            var mockRepo = new Mock<ITeamUserRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(teamUserList);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(teamUserList.First());

            mockRepo.Setup(r => r.GetTeamUsersAsync(It.IsAny<long>()))
                .ReturnsAsync(teamUserList);

            mockRepo.Setup(r => r.GetTeamUserAsync(It.IsAny<long>(), It.IsAny<long>()))
                .ReturnsAsync(teamUserList.First());

            mockRepo.Setup(r => r.AddAsync(It.IsAny<UserTeam>()))
                .Callback((UserTeam teamUser) =>
                {
                    teamUserList.Add(teamUser);
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<UserTeam>()))
                .Callback((UserTeam teamUser) =>
                {
                    teamUserList.Remove(teamUser);
                });

            mockRepo.Setup(r => r.RemoveTeamUsersAsync(It.IsAny<List<UserTeam>>()))
                .Callback(() =>
                {
                    teamUserList.Clear();
                });

            return mockRepo;
        }
    }
}
