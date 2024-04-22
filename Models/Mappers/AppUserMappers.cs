using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;

namespace Models.Mappers
{
    public static class AppUserMappers
    {
        public static ApplicationUser ToAppUserFromCreate(this CreateAppUserDeCeroDto createAppUserDto)
        {
            return new ApplicationUser
            {
                UserName = createAppUserDto.Badgenumber.ToString(),
                Email = createAppUserDto.Email
            };
        }
        public static ApplicationUser ToAppUserFromCreateDeUserinfo(this CreateAppUserDeUserinfoDto createAppUserDto)
        {
            return new ApplicationUser
            {
                UserinfoId = createAppUserDto.UserinfoId,
                UserName = createAppUserDto.Badgenumber.ToString(),
                Email = createAppUserDto.Email,
            };
        }

        public static ApplicationUser ToAppUserFromAppAdmin(this CreateAppAdminDto createAppAdminDto)
        {
            return new ApplicationUser
            {
                UserName = createAppAdminDto.UserName,
                Email = createAppAdminDto.Email                
            };
        }


        public static AppUserViewDto ToAppUserViewDto(this ApplicationUser appUser)
        {
            return new AppUserViewDto
            {
                UserName = appUser.UserName,         
                Email = appUser.Email,
                RefreshToken = appUser.RefreshToken,
                RefreshTokenExpiry = appUser.RefreshTokenExpiry is null ? (DateTime?)null : appUser.RefreshTokenExpiry.Value,
            };
        }
    }
}
