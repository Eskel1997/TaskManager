using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Project;
using TASKMANAGER.INFRASTRUCTURE.Handlers.Project;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mock;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mocks;
using Xunit;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Handlers
{
    public class ProjectTests
    {
        private readonly Mock<IProjectRepository> _projectRepository;
        private readonly Mock<ITeamRepository> _teamRepository;
        private readonly Mock<IPermissionsService> _permissionService;
        private readonly CreateProjectHandler _createHandler;

        public ProjectTests()
        {
            _projectRepository = MockProjectRepository.GetProjectRepository();
            _teamRepository = MockTeamRepository.GetTeamRepository();
            _permissionService = MockPermissionService.GetPermissionService();
            _createHandler = new CreateProjectHandler(
                _projectRepository.Object,
                _teamRepository.Object,
                _permissionService.Object);
        }

        [Fact]
        public async Task CreateProject()
        {
            var createProjectCom = new CreateProjectCommand()
            {
                Name = "Test project 1",
                Status = DB.Enums.ProjectStatusEnum.Added,
                TeamId = Guid.NewGuid(),
                UserId = 1
            };

            var result = await _createHandler.Handle(createProjectCom, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var projects = await _projectRepository.Object.GetAllAsync();

            projects.Count.Should().Be(4);
        }
    }
}
