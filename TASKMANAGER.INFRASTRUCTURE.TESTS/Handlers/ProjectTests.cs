﻿using FluentAssertions;
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
        private readonly DeleteProjectHandler _deleteHandler;
        private readonly UpdateProjectHandler _updateHandler;

        public ProjectTests()
        {
            _projectRepository = MockProjectRepository.GetProjectRepository();
            _teamRepository = MockTeamRepository.GetTeamRepository();
            _permissionService = MockPermissionService.GetPermissionService();
            _createHandler = new CreateProjectHandler(
                _projectRepository.Object,
                _teamRepository.Object,
                _permissionService.Object);

            _deleteHandler = new DeleteProjectHandler(
              _projectRepository.Object,
              _permissionService.Object);

            _updateHandler = new UpdateProjectHandler(
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

        [Fact]
        public async Task CreateProject_WithoutPermissions_ThrowsForbiddenException()
        {
            var createProjectCom = new CreateProjectCommand()
            {
                Name = "Test project 1",
                Status = DB.Enums.ProjectStatusEnum.Added,
                TeamId = Guid.NewGuid(),
                UserId = 2
            };

            try
            {
                var result = await _createHandler.Handle(createProjectCom, CancellationToken.None);
                result.Should().NotBe(Unit.Value);
            }
            catch (TaskManagerException ex)
            {
                ex.Should().BeOfType<TaskManagerException>();
                ex.ErrorCode.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            }
        }

        [Fact]
        public async Task DeleteProject()
        {
            var deleteProjectCom = new DeleteProjectCommand(Guid.NewGuid())
            {
                UserId = 1
            };

            var result = await _deleteHandler.Handle(deleteProjectCom, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var projects = await _projectRepository.Object.GetAllAsync();

            projects.Count.Should().Be(2);
        }

        [Fact]
        public async Task DeleteProject_WithoutPermissions_ThrowsForbiddenException()
        {
            var deleteProjectCom = new DeleteProjectCommand(Guid.NewGuid())
            {
                UserId = 2
            };

            try
            {
                var result = await _deleteHandler.Handle(deleteProjectCom, CancellationToken.None);
                result.Should().NotBe(Unit.Value);
            }
            catch (TaskManagerException ex)
            {
                ex.Should().BeOfType<TaskManagerException>();
                ex.ErrorCode.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            }
        }

        [Fact]
        public async Task UpdateProject()
        {
            Guid publicId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            string name = "Test project 2";
            var updateProjectCom = new UpdateProjectCommand()
            {
                Name = name,
                UserId = 1,
                PublicId = publicId,
                Status = DB.Enums.ProjectStatusEnum.InProgress,
                TeamId = teamId,
            };

            var result = await _updateHandler.Handle(updateProjectCom, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var project = await _projectRepository.Object.GetByIdAsync(1);
            project.Name.Should().Be(name);
            project.Status.Should().Be((int)DB.Enums.ProjectStatusEnum.InProgress);
        }

        [Fact]
        public async Task UpdateProject_WithoutPermissions_ThrowsForbiddenException()
        {
            Guid publicId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            string name = "Test project 2";
            var updateProjectCom = new UpdateProjectCommand()
            {
                Name = name,
                UserId = 2,
                PublicId = publicId,
                Status = DB.Enums.ProjectStatusEnum.InProgress,
                TeamId = teamId,
            };

            try
            {
                var result = await _updateHandler.Handle(updateProjectCom, CancellationToken.None);
                result.Should().Be(Unit.Value);
            }
            catch (TaskManagerException ex)
            {
                ex.Should().BeOfType<TaskManagerException>();
                ex.ErrorCode.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}
