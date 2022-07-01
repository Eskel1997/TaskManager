using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Comment;
using TASKMANAGER.INFRASTRUCTURE.Handlers.Comment;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mock;
using Xunit;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Handlers
{
    public class CommentTests
    {
        private readonly Mock<ITaskRepository> _taskRepository;
        private readonly Mock<ICommentRepository> _commentRepository;
        private readonly CreateCommandHandler _createHandler;
        private readonly DeleteCommentHandler _deleteHandler;

        public CommentTests()
        {
            _taskRepository = MockTaskRepository.GetTaskRepository();
            _commentRepository = MockCommentRepository.GetCommentRepository();
            _createHandler = new CreateCommandHandler(_commentRepository.Object, _taskRepository.Object);
            _deleteHandler = new DeleteCommentHandler(_commentRepository.Object);
        }

        [Fact]
        public async Task CreateComment()
        {
            var createCommentCom = new CreateCommentCommand()
            {
                Comment = "Test comment",
                UserId = 1,
                TaskId = Guid.NewGuid(),
            };

            var result = await _createHandler.Handle(createCommentCom, CancellationToken.None);
            result.Should().Be(Unit.Value);

            var comments = await _commentRepository.Object.GetAllAsync();
            comments.Count.Should().Be(4);
        }

        [Fact]
        public async Task DeleteComment()
        {
            var deleteCommentCom = new DeleteCommentCommand()
            {
                PublicId = Guid.NewGuid(),
                UserId = 1
            };

            var result = await _deleteHandler.Handle(deleteCommentCom, CancellationToken.None);
            result.Should().Be(Unit.Value);

            var comments = await _commentRepository.Object.GetAllAsync();
            comments.Count.Should().Be(2);
        }
    }
}
