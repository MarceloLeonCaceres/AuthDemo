using DataRepository.Interfaces.AuthAppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Models.Entities.AuthAppUser;

namespace ApiProperJwt3.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController (IRolesRepo rolesRepo, ILogger<RolesController> logger): ControllerBase
    {

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateRole(string name)
        {
            // Check if the role exist
            bool roleExist = await rolesRepo.RoleExist(name);
            if(roleExist)
            {
                return BadRequest("El rol ya existe.");
            }

            var roleResult = await rolesRepo.CreateRole(name);
            if(roleResult.Succeeded)
            {
                return Ok($"El rol {name} fue creado exitosamente.");
            }
            else
            {
                return BadRequest(roleResult.Errors);
            }
        }


        [HttpGet("GetRoles")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await rolesRepo.GetRolesAsync();
            if(roles == null)
            {
                logger.LogWarning("No hay roles.");
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpGet("GetUserRoles")]
        [Authorize(Roles ="th, admin")]
        public async Task<IActionResult> GetAppUserRoles(string username)
        {
            var appUsersRole = await rolesRepo.GetAppUserRoles(username);
            if(appUsersRole == null)
            {
                return NotFound("Usuario no encontrado.");
            }
            return Ok(appUsersRole);
        }

        [HttpPost("AddUserToRole")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> AddUserToRole(string username, string roleName)
        {
            var result = await rolesRepo.AddUserToRole(username, roleName);
            if (result == null)
            {
                logger.LogWarning("Usuario o rol no existen.");
                return BadRequest("Usuario o rol no existen.");
            }
            else if (result.Succeeded == false)
            {
                logger.LogWarning("No se pudo asignar rol-user.");
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }
            return Ok("El user-rol fue asignado.");
        }

        [HttpDelete("RemoveUserFromRole")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> RemoveUserFromRole(string username, string roleName)
        {
            var result = await rolesRepo.RemoveAppUserFromRole(username, roleName);
            if(result == null)
            {
                logger.LogWarning("Usuario o rol no existen.");
                return BadRequest("Usuario o rol no existen.");
            }
            else if(result.Succeeded == false)
            {
                logger.LogWarning("No se pudo remover rol-user.");
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }
            return Ok("El user-rol fue quitado.");
        }
    }
}
