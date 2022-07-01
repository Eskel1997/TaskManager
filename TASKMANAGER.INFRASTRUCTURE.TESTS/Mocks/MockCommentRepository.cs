using Moq;
using System.Collections.Generic;
using System.Linq;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Mock
{
    public static class MockCommentRepository
    {
        internal static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Comment>
            {
                new Comment("Testowy 1", 1, 1),
                new Comment("Testowy 2", 1, 1),
                new Comment("Testowy 3", 1, 1)
            };


            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(comments);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(comments.First());

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Comment>()))
                .Callback((Comment comment) =>
                {
                    comments.Add(comment);
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Comment>()))
                .Callback((Comment comment) =>
                {
                    comments.Remove(comment);
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Comment>()))
                .Callback((Comment comment) =>
                {
                    comments[0].ChangeText(comment.Text);
                });

            return mockRepo;
        }
    }
}
