using FluentAssertions;
using Moq;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Managers.Concrete;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Services.Concrete;
using TASKMANAGER.INFRASTRUCTURE.TESTS.Mock;
using Xunit;

namespace TASKMANAGER.INFRASTRUCTURE.TESTS
{
    public class UserTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly IEncryptionManager _encryptionManager;
        private readonly IUserService _userService;
        public UserTests()
        {
            _mockRepository = MockUserRepository.GetUserTypeRepository();
            _encryptionManager = new EncryptionManager();
            _userService = new _userService(_mockRepository.Object, _encryptionManager);
        }
        [Theory]
        [InlineData("Test","testPicture", "test", "username", "email@email.com", "Password")]
        public async void CreateUser_ReturnRegisterUser(string name, string pictureUrl,
            string lastName, string username, string email, string password)
        { 
            var result = await _userService.RegisterUserAsync(name, pictureUrl, lastName, username, email, password);

            result.Should().BeOfType(typeof(User));
            result.Name.Should().Be(name);
            result.Email.Should().Be(email);
        }
    }
}
