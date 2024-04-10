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
                //Badgenumber = createAppUserDto.Badgenumber,
                //OtAdmin = createAppUserDto.OtAdmin,
                UserName = createAppUserDto.Badgenumber.ToString(),
                Email = createAppUserDto.Email
            };
        }


        public static AppUserViewDto ToAppUserViewDto(this AppUser appUser)
        {
            return new AppUserViewDto
            {
                Badgenumber = appUser.UserName,
                //OtAdmin = appUser.,
                //UserName = appUser.Badgenumber.ToString(),
                Email = appUser.Email,
                RefreshToken = appUser.RefreshToken,
                RefreshTokenExpiry = appUser.RefreshTokenExpiry,
            };
        }
    }
}
