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
        private readonly DeleteTaskHandler _deleteHandler;
        private readonly UpdateTaskHandler _updateHandler;

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
            _deleteHandler = new DeleteTaskHandler(
                _taskRepository.Object,
                _permissionService.Object);
            _updateHandler = new UpdateTaskHandler(
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

        [Fact]
        public async Task CreateTask_WithoutPermissions_ThrowsForbiddenException()
        {
            var createTaskCom = new CreateTaskCommand()
            {
                Name = "Test task 1",
                Description = "test",
                OwnerId = Guid.NewGuid(),
                Priority = DB.Enums.TaskPriorityEnum.Medium,
                ProjectId = Guid.NewGuid(),
                Status = DB.Enums.TaskStatusEnum.Added,
                UserId = 2
            };

            try
            {
                var result = await _createHandler.Handle(createTaskCom, CancellationToken.None);
                result.Should().NotBe(Unit.Value);
            }
            catch (TaskManagerException ex)
            {
                ex.Should().BeOfType<TaskManagerException>();
                ex.ErrorCode.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            }
        }
        [Fact]
        public async Task DeleteTask()
        {
            var deleteTaskCom = new DeleteTaskCommand(Guid.NewGuid())
            {
                UserId = 1
            };

            var result = await _deleteHandler.Handle(deleteTaskCom, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var tasks = await _taskRepository.Object.GetAllAsync();

            tasks.Count().Should().Be(2);
        }

        [Fact]
        public async Task DeleteTask_WithoutPermissions_ThrowsForbiddenException()
        {
            var deleteTaskCom = new DeleteTaskCommand(Guid.NewGuid())
            {
                UserId = 2
            };

            try
            {
                var result = await _deleteHandler.Handle(deleteTaskCom, CancellationToken.None);
                result.Should().NotBe(Unit.Value);
            }
            catch (TaskManagerException ex)
            {
                ex.Should().BeOfType<TaskManagerException>();
                ex.ErrorCode.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            }
        }

        [Fact]
        public async Task UpdateTask()
        {
            var description = "Testowy opis";
            var name = "aktualizacja zadania";
            var id = Guid.NewGuid();
            var priority = DB.Enums.TaskPriorityEnum.Medium;
            var ownerId = Guid.NewGuid();
            var status = DB.Enums.TaskStatusEnum.Ended;
            var updateTaskCom = new UpdateTaskCommand()
            {
                Description = description,
                Name = name,
                PublicId = id,
                ProjectId = Guid.NewGuid(),
                Priority = priority,
                OwnerId = ownerId,
                UserId = 1,
                Status = status
            };


            var result = await _updateHandler.Handle(updateTaskCom, CancellationToken.None);
            result.Should().Be(Unit.Value);

            var task = await _taskRepository.Object.GetByIdAsync(id.ToString());
            task.Status.Should().Be((int)status);
            task.Description.Should().Be(description);
            task.Name.Should().Be(name);
            task.Priority.Should().Be((int)priority);
        }
    }
}
