using DataRepository.Interfaces.AuthAppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProperJwt3.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController(IClaimRepo claimRepo, ILogger<ClaimsController> logger) : ControllerBase
    {
        [HttpGet("GetClaims")]
        public async Task<IActionResult> GetAllClaims(string username)
        {
            var userClaims = await claimRepo.GetAllClaims(username);
            if(userClaims == null)
            {
                return BadRequest("Usuarion no existe");
            }
            return Ok(userClaims);
        }

        [HttpPost("AddClaimsToUser")]
        [Authorize(Roles = "th")]
        public async Task<IActionResult> AddClaimsToUser(string badgenumber, string claimName, string claimValue)
        {
            var result = await claimRepo.AddClaimsToUser(badgenumber, claimName, claimValue);
            if(result == null)
            {
                return BadRequest(new { error = "Usuario no existe" });
            }
            else if(result.Succeeded == false)
            {
                logger.LogWarning("Error al agregar claim al usuario.");
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }
            return Ok($"El claim {claimName} fue asignado correctamente al usuario {badgenumber}");
        }

        [HttpDelete("RemoveClaimsFromUser")]
        [Authorize(Roles = "th")]
        public async Task<IActionResult> RemoveClaimFromUser(string badgenumber, string claimName, string claimValue)
        {
            var result = await claimRepo.RemoveClaimFromUser(badgenumber, claimName, claimValue);
            if (result == null)
            {
                return BadRequest(new { error = "Usuario no existe" });
            }
            else if (result.Succeeded == false)
            {
                logger.LogWarning("Error al quitar claim del usuario.");
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }
            return Ok($"El claim {claimName} fue removido correctamente del usuario {badgenumber}");
        }
    }
}
