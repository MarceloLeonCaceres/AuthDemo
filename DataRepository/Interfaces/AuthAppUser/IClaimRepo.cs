using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DataRepository.Interfaces.AuthAppUser
{
    public interface IClaimRepo
    {
        Task<IdentityResult?> AddClaimsToUser(string badgenumber, string claimName, string claimValue);
        Task<List<Claim>?> GetAllClaims(string badgenumber);
        Task<IdentityResult?> RemoveClaimFromUser(string badgenumber, string claimName, string claimValue);
    }
}
