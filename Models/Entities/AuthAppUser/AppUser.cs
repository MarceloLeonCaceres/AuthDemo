using Microsoft.AspNetCore.Identity;
using Models.Entities.Enums;

namespace Models.Entities.AuthAppUser
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public virtual ICollection<AppUserRole>? AppUserRoles { get; set; }   
    }
}
