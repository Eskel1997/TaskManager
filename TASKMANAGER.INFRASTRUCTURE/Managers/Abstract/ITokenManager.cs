using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.INFRASTRUCTURE.Managers.Abstract
{
    public interface ITokenManager
    {
        public TokenModel GenerateToken(long userId, string userPublicId, string email, string name, string surname, string pictureUrl);
        public long GetIdFromToken(string token);
        public void CompareRefreshTokens(string givenToken, string refreshToken);
    }
}
