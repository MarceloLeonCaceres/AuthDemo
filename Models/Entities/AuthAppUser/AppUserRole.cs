using Microsoft.AspNetCore.Identity;

namespace Models.Entities.AuthAppUser
{
    public class AppUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser AppUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
