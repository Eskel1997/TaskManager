using Moq;
using System.Collections.Generic;
using System.Linq;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mock
{
    internal static class MockTaskRepository
    {
        public static Mock<ITaskRepository> GetTaskRepository()
        {
            var tasks = new List<Task>()
            {
                new Task("Zadanie 1", 1, "Testowe zadanie 1", 1, 1, 1, 0),
                new Task("Zadanie 2", 1, "Testowe zadanie 2", 1, 1, 1, 0),
                new Task("Zadanie 3", 1, "Testowe zadanie 3", 1, 1, 1, 0),
            };

            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(tasks);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(tasks.First());

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(tasks.First());

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Task>()))
                .Callback((Task task) =>
                {
                    tasks.Add(task);
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Task>()))
                .Callback((Task task) =>
                {
                    tasks[0].Update(task.Name, task.Priority, task.Description, task.ProjectId, task.OwnerId, task.Status);
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Task>()))
                .Callback((Task task) =>
                {
                    tasks.Remove(task);
                });

            return mockRepo;
        }
    }
}
