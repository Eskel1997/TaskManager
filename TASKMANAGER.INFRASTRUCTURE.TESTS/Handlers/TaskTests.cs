using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Task;
using TASKMANAGER.INFRASTRUCTURE.Handlers.Task;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mock;
using Xunit;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Handlers
{
    public class TaskTests
    {
        private readonly Mock<IProjectRepository> _projectRepository;
        private readonly Mock<ITaskRepository> _taskRepository;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IPermissionsService> _permissionService;
        private readonly CreateTaskHandler _createHandler;

        public TaskTests()
        {
            _projectRepository = MockProjectRepository.GetProjectRepository();
            _taskRepository = MockTaskRepository.GetTaskRepository();
            _permissionService = MockPermissionService.GetPermissionService();
            _userRepository = MockUserRepository.GetUserTypeRepository();
            _createHandler = new CreateTaskHandler(
                _projectRepository.Object,
                _userRepository.Object,
                _taskRepository.Object,
                _permissionService.Object);
        }

        [Fact]
        public async Task CreateTask()
        {
            var createTaskCom = new CreateTaskCommand()
            {
                Name = "Test task 1",
                Description = "test",
                OwnerId = Guid.NewGuid(),
                Priority = DB.Enums.TaskPriorityEnum.Medium,
                ProjectId = Guid.NewGuid(),
                Status = DB.Enums.TaskStatusEnum.Added,
                UserId = 1
            };

            var result = await _createHandler.Handle(createTaskCom, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var tasks = await _taskRepository.Object.GetAllAsync();

            tasks.Count.Should().Be(4);
        }
    }
}
