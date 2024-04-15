using Microsoft.AspNetCore.Identity;
using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;
using static Models.DTOs.AuthAppUser.ServiceResponses;

namespace DataRepository.Interfaces.AuthAppUser
{
    public interface IAuthService
    {
        Task<List<AppUserViewDto>?> GetAllAppUsers();
        Task<AppUserViewDto?> GetAppUserByUsername(string username);
        Task<List<AppUserProfileViewDto>?> GetAppUsersProfileView();
        Task<IdentityResult?> CreateAppAdmin(CreateAppAdminDto createAppAdmino);
        Task<IdentityResult?> CreateAppUser(CreateAppUserDeCeroDto createAppUserDeCero);
        Task<IdentityResult?> UpdatePerfilAppUser(string username, PerfilAppAdminDto convertToUserDto);
        Task<IdentityResult?> DeleteAppUser(string username);
        Task<bool?> ExisteAppUser(string username);
        Task<TokenResponse> Login(LoginDto user);
        Task<IdentityResult?> ChangePassword(string username, ChangePasswordDto changePwdDto);
        Task<TokenResponse> RefreshToken(RefreshTokenModel refreshModel);
        Task<TokenResponse> Revoke(string username);
    }
}
