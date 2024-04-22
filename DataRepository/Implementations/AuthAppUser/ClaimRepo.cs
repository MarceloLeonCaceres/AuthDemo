using DataRepository.Interfaces.AuthAppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models.Entities.AuthAppUser;
using System.Security.Claims;

namespace DataRepository.Implementations.AuthAppUser
{
    public class ClaimRepo(
        UserManager<ApplicationUser> userManager,
        RoleManager<Role> roleManager,
        ILogger<ClaimRepo> logger,
        IConfiguration config
        ) : IClaimRepo
    {

        public async Task<List<Claim>?> GetAllClaims(string badgenumber)
        {
            // Revisar si el usuario existe
            var user = await userManager.FindByNameAsync(badgenumber);
            if( user == null )
            {
                logger.LogWarning($"Usuario no existe {badgenumber}");
                return null;
            }
            var userClaims = await userManager.GetClaimsAsync(user);
            return (List<Claim>)userClaims;
        }

        public async Task<IdentityResult?> AddClaimsToUser(string badgenumber, string claimName, string claimValue)
        {
            // Revisar si el usuario existe
            var user = await userManager.FindByNameAsync(badgenumber);
            if (user == null)
            {
                logger.LogWarning($"Usuario no existe {badgenumber}");
                return null;
            }

            // Revisa si ya tiene el claim con otro valor
            var userClaims = await userManager.GetClaimsAsync(user);
            foreach(Claim claim in userClaims)
            {
                if(claim.Type.ToLower() == claimName.ToLower())
                {
                    logger.LogWarning($"El usuario {badgenumber} ya tiene ese claim {claimName}");
                    return null;
                }
            }

            //Crea el claim
            var userClaim = new Claim(claimName, claimValue);

            // Asigna el claim al usuario
            var result = await userManager.AddClaimAsync(user, userClaim);
            return result;
        }

        public async Task<IdentityResult?> RemoveClaimFromUser(string badgenumber, string claimName, string claimValue)
        {
            // Revisar si el usuario existe
            var user = await userManager.FindByNameAsync(badgenumber);
            if (user == null)
            {
                logger.LogWarning($"Usuario no existe {badgenumber}");
                return null;
            }

            //Crea el claim
            var userClaim = new Claim(claimName, claimValue);

            // Quita el claim del usuario
            var result = await userManager.RemoveClaimAsync(user, userClaim);
            return result;
        }
    }
}
