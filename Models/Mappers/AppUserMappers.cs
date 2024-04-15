using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;

namespace Models.Mappers
{
    public static class AppUserMappers
    {
        public static AppUser ToAppUserFromCreate(this CreateAppUserDeCeroDto createAppUserDto)
        {
            return new AppUser
            {
                UserName = createAppUserDto.Badgenumber.ToString(),
                Email = createAppUserDto.Email
            };
        }

        public static AppUser ToAppUserFromAppAdmin(this CreateAppAdminDto createAppAdminDto)
        {
            return new AppUser
            {
                UserName = createAppAdminDto.UserName,
                Email = createAppAdminDto.Email                
            };
        }


        public static AppUserViewDto ToAppUserViewDto(this AppUser appUser)
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
