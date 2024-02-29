using WebApiJwtIdentity.Models;

namespace WebApiJwtIdentity.Services
{
    public interface IAuthService
    {
        string GenerateTokenString(string userName);
        Task<LoginResponse> Login(LoginUser user);
        Task<LoginResponse> RefreshToken(RefreshTokenModel refreshModel);
        Task<bool> RegisterUser(LoginUser user);
        Task<LoginResponse> Revoke(string username);
    }
}