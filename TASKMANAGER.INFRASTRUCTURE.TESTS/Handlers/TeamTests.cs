﻿using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;
using TASKMANAGER.INFRASTRUCTURE.Handlers.Team;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mock;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mocks;
using Xunit;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS.Handlers
{
    public class TeamTests
    {
        private readonly Mock<ITeamRepository> _teamRepository;
        private readonly Mock<IPermissionsService> _permissionService;
        private readonly Mock<ITeamUserRepository> _teamUserRepository;
        private readonly CreateTeamHandler _createHandler;
        private readonly DeleteTeamHandler _deleteHandler;

        public TeamTests()
        {
            _teamRepository = MockTeamRepository.GetTeamRepository();
            _permissionService = MockPermissionService.GetPermissionService();
            _teamUserRepository = MockTeamUserRepository.GetTeamUserRepository();

            _createHandler = new CreateTeamHandler(
                _teamRepository.Object,
                _permissionService.Object);

            _deleteHandler = new DeleteTeamHandler(
                _teamRepository.Object,
                _permissionService.Object,
                _teamUserRepository.Object);
        }

        [Fact]
        public async Task CreateTeam()
        {
            var request = new CreateTeamCommand()
            {
                Name = "Test team",
                UserId = 1
            };

            var result = await _createHandler.Handle(request, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var teams = await _teamRepository.Object.GetAllAsync();

            teams.Count.Should().Be(4);
        }

        [Fact]
        public async Task CreateTeam_WithoutPermissions_ThrowsForbiddenException()
        {
            var createTeamCom = new CreateTeamCommand()
            {
                Name = "Test team",
                UserId = 2
            };

            try
            {
                var result = await _createHandler.Handle(createTeamCom, CancellationToken.None);
                result.Should().NotBe(Unit.Value);
            }
            catch (TaskManagerException ex)
            {
                ex.Should().BeOfType<TaskManagerException>();
                ex.ErrorCode.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            }
        }

        [Fact]
        public async Task DeleteTeam()
        {
            var request = new DeleteTeamCommand(Guid.NewGuid())
            {
                UserId = 1
            };

            var result = await _deleteHandler.Handle(request, CancellationToken.None);

            result.Should().Be(Unit.Value);

            var teams = await _teamRepository.Object.GetAllAsync();

            teams.Count.Should().Be(2);
        }

    }
}
