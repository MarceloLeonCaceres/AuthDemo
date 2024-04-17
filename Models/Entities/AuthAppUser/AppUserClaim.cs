using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Models.Entities.AuthAppUser
{
    public class AppUserClaim : IdentityUserClaim<string>
    {
        public virtual AppUser AppUser { get; set; }

        public AppUserClaim(string userId, string claimType, string claimValue)
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        public AppUserClaim(int id, string userId, string claimType, string claimValue)
        {
            Id = id;
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        public AppUserClaim()
        {
        }
    }
}
