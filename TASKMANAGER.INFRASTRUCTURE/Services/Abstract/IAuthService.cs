using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Models;

namespace TASKMANAGER.INFRASTRUCTURE.Services.Abstract
{
    public interface IAuthService : IService
    {
        Task<TokenModel> LoginUserAsync(string email, string password);
        Task<TokenModel> RefreshTokenAsync(string jwtToken, string refreshToken);
    }
}
