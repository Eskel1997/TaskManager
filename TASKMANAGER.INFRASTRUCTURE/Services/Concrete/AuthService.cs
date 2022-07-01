using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Services.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Services.Concrete
{
    internal class _authService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManager _tokenManager;
        private readonly IEncryptionManager _encryptionManager;

        public _authService(
            IUserRepository userRepository,
            ITokenManager tokenManager,
            IEncryptionManager encryptionManager)
        {
            _userRepository = userRepository;
            _tokenManager = tokenManager;
            _encryptionManager = encryptionManager;
        }

        public async Task<TokenModel> LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                throw new TaskManagerException(ErrorCode.NotFound);
            }

            var hash = _encryptionManager.GetHash(password, user.PasswordSalt);
            _encryptionManager.CompareHash(user.PasswordHash, hash);

            var tokenModel = _tokenManager.GenerateToken(user.Id, user.PublicId.ToString(), user.Email, user.Name, user.LastName, user.PictureUrl);

            user.ChangeRefreshToken(tokenModel.RefreshToken);
            await _userRepository.SaveChangesAsync();

            return tokenModel;
        }

        public async Task<TokenModel> RefreshTokenAsync(string jwtToken, string refreshToken)
        {
            var userId = _tokenManager.GetIdFromToken(jwtToken);
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new TaskManagerException(ErrorCode.NotFound);
            }

            _tokenManager.CompareRefreshTokens(refreshToken, user.RefreshToken);

            var tokenDto = _tokenManager.GenerateToken(user.Id,user.PublicId.ToString(), user.Email, user.Name, user.LastName, user.PictureUrl);

            user.ChangeRefreshToken(tokenDto.RefreshToken);
            await _userRepository.SaveChangesAsync();

            return tokenDto;
        }
    }
}
