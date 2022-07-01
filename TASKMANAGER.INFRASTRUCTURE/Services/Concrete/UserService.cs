using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TASKMANAGER.DB.Entities.Concrete;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Services.Concrete
{
    public class _userService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionManager _encryptionManager;

        public _userService(
            IUserRepository userRepository,
            IEncryptionManager encryptionManager)
        {
            _userRepository = userRepository;
            _encryptionManager = encryptionManager;
        }

        public async System.Threading.Tasks.Task ChangeUserPassword(long userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var hash = _encryptionManager.GetHash(oldPassword, user.PasswordSalt);
            _encryptionManager.CompareHash(user.PasswordHash, hash);

            //Generate new has and Salt
            var newSalt = _encryptionManager.GetSalt();
            var newHash = _encryptionManager.GetHash(newPassword, newSalt);

            user.ChangePassword(newHash, newSalt);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<User> RegisterUserAsync(string name, string pictureUrl, string lastName, string username, string email, string password)
        {
            var user = new User();

            return user;
        }
    }
}
