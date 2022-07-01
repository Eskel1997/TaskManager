using Moq;
using System.Collections.Generic;
using System.Linq;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mocks
{
    internal static class MockTeamRepository
    {
        public static Mock<ITeamRepository> GetTeamRepository()
        {

            var teams = new List<Team>()
            {
                new Team("Team 1", 1),
                new Team("Team 2", 1),
                new Team("Team 3", 1)
            };

            var mockRepo = new Mock<ITeamRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(teams);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(teams.First());

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(teams.First());

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Team>()))
                .Callback((Team team) =>
                {
                    teams.Add(team);
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Team>()))
                .Callback((Team team) =>
                {
                    teams[0].ChangeName(team.Name);
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Team>()))
                .Callback((Team team) =>
                {
                    teams.Remove(team);
                });

            mockRepo.Setup(r => r.RemoveUsers(It.IsAny<List<UserTeam>>()))
                .Callback((List<UserTeam> users) =>
                {
                    teams.First().TeamUsers.Remove(users[0]);
                });

            return mockRepo;
        }
    }
}
