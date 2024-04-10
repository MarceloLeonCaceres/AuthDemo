using Microsoft.AspNetCore.Identity;

namespace Models.Entities.AuthAppUser
{
    public class AppUserRole : IdentityUserRole<string>
    {
        public virtual AppUser AppUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
