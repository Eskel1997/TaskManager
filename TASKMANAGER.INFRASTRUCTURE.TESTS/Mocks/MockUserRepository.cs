using System;
using System.Collections.Generic;
using System.Text;
using TASKMANAGER.DB.Repositories.Abstract;
using Moq;
using TASKMANAGER.DB.Entities.Concrete;
using System.Linq;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mock
{
    internal static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserTypeRepository()
        {
            var users = new List<User>
            {
                new User("Piotr", "xxxx", "Kosiba", "p.kosiba", "p.kosiba@test.pl", "XXSDSDSDS", "dadlkldad"),
                new User("Adam", "yyyy", "Tester", "a.tester", "a.tester@test.pl", "XXSDSDs", "dadasda"),
                new User("Johny", "zzz", "Bravo", "j.bravo", "j.bravo@test.pl", "xdsdsad", "dadarawd")
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(users);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<User>()))
                .Callback((User user) =>
                {
                    users.Add(user);
                });

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(users.First());

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(users.First());

            return mockRepo;
        }
    }
}
