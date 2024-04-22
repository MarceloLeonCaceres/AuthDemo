using Microsoft.AspNetCore.Identity;
using Models.Entities.Enums;

namespace Models.Entities.AuthAppUser
{
    public class ApplicationUser : IdentityUser
    {
        public int? UserinfoId { get; set; }
        public Userinfo? Userinfo { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public virtual ICollection<AppUserRole>? AppUserRoles { get; set; }   
        public virtual ICollection<IdentityUserClaim<string>>? AppUserClaims { get; set; }
    }
}
