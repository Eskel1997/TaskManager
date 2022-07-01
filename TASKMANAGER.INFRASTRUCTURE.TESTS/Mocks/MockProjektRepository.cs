using Moq;
using System.Collections.Generic;
using System.Linq;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mock
{
    internal static class MockProjectRepository
    {
        public static Mock<IProjectRepository> GetProjectRepository()
        {
            var projects = new List<Project>()
            {
                new Project("Projekt 1", DB.Enums.ProjectStatusEnum.Added, 1),
                new Project("Projekt 2", DB.Enums.ProjectStatusEnum.Added, 1),
                new Project("Projekt 3", DB.Enums.ProjectStatusEnum.Added, 1)
            };

            var mockRepo = new Mock<IProjectRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(projects);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(projects.First());

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(projects.First());

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Project>()))
                .Callback((Project project) =>
                {
                    projects.Add(project);
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Project>()))
                .Callback((Project project) =>
                {
                    projects[0].Update(project.Name, (ProjectStatusEnum)project.Status, project.TeamId);
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Project>()))
                .Callback((Project project) =>
                {
                    projects.Remove(project);
                });

            return mockRepo;
        }
    }
}
