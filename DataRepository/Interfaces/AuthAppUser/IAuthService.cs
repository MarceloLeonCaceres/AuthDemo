using Microsoft.AspNetCore.Identity;
using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;
using static Models.DTOs.AuthAppUser.ServiceResponses;

namespace DataRepository.Interfaces.AuthAppUser
{
    public interface IAuthService
    {
        Task<IdentityResult?> CreateAppUser(CreateAppUserDeCeroDto createAppUserDeCero);
        Task<IdentityResult?> UpdatePerfilAppUser(string badgenumber, PerfilAppUserDto convertToUserDto);
        Task<TokenResponse> Login(LoginDto user);
        Task<List<AppUserViewDto>?> GetAllAppUsers();
        Task<AppUserViewDto?> GetAppUserByUsername(string username);
        Task<IdentityResult?> DeleteAppUser(string badgenumber);
        Task<IdentityResult?> ChangePassword(string username, ChangePasswordDto changePwdDto);
        Task<TokenResponse> RefreshToken(RefreshTokenModel refreshModel);
        Task<TokenResponse> Revoke(string username);
        Task<List<AppUserProfileViewDto>?> GetAppUsersProfileView();
    }
}
