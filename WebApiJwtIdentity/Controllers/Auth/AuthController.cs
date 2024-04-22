using DataRepository.Implementations;
using DataRepository.Interfaces;
using DataRepository.Interfaces.AuthAppUser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ApiProperJwt3.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(IAuthService authService, 
            ILogger<AuthController> logger,
            IUserinfoRepo userinfoRepo)
        {
            _authService = authService;
            _logger = logger;
            _userinfoRepo = userinfoRepo;
        }

        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly IUserinfoRepo _userinfoRepo;

        private async Task<AppUserViewDto?> GetCurrentAppUser()
        {
            var badge = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (badge == null) { return null; }
            var appUser = await _authService.GetAppUserByUsername(badge);
            return appUser;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto user)
        {
            _logger.LogInformation("Login called.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loginResult = await _authService.Login(user);
            if (loginResult.IslogedIn)
            {
                _logger.LogInformation("Login suceeded");
                return Ok(loginResult);
            }
            return Unauthorized("Usuario o password incorrectos");
        }

        [HttpPost("CreateAppAdmin")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> CreateAppAdmin(CreateAppAdminDto appAdminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _authService.CreateAppAdmin(appAdminDto);
            if (response == null)
            {
                return NotFound($"No se encontró el departamento indicado.");
            }
            if (response.Succeeded == false)
            {
                return BadRequest($"No se pudo crear el usuario. {response.Errors.FirstOrDefault().Description} ");
            }
            return Ok("Se creó el usuario con todos los roles!!");

        }

        [HttpPost("CreateAppUser")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> CreateAppUser(CreateAppUserDeCeroDto appUserDeCeroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _authService.CreateAppUser(appUserDeCeroDto);
            if (response == null )
            {
                return BadRequest($"No se pudo crear el usuario.");
            }
            if(response.Succeeded == false)
            {
                return BadRequest($"No se pudo crear el usuario. {response.Errors.FirstOrDefault().Description}");
            }
            return Ok("Se creó el usuario con todos los roles!!");

        }

        [HttpPost("UpdatePerfil/{badgenumber}")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> ConvertToAppUser(string badgenumber, [FromBody] PerfilAppAdminDto nuevoPerfil )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await  _authService.UpdatePerfilAppUser(badgenumber, nuevoPerfil);
            if(result == null)
            {
                return NotFound($"No se pudo encontrar este empleado {badgenumber}.");
            }
            if(result.Succeeded == false)
            {
                return BadRequest($"Se presentó un error que no dejó actualizar el perfil del empleado. {result.Errors.FirstOrDefault().Description}");
            }

            return Ok("El perfil se modificó.");

        }


        [HttpGet("getAllAppUsers")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAppUsers()
        {
            var appUsers = await _authService.GetAllAppUsers();
            if (appUsers == null)
            {
                return NotFound("No hay AppUsers.");
            }
            return Ok(appUsers);
        }

        [HttpGet("GetUserByName")]
        [Authorize]
        public async Task<IActionResult> GetAppUserByUsername(string username)
        {
            var appUser = await _authService.GetAppUserByUsername(username);
            if (appUser == null)
            {
                return NotFound("No hay un usuario con ese username");
            }
            return Ok(appUser);
        }

        [HttpGet("GetAppUsersProfileView")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAppUsersProfileView()
        {
            var result = await _authService.GetAppUsersProfileView();
            return Ok(result);
        }

        [HttpDelete("DeleteAppUser")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> DeleteAppUser(string badgenumber)
        {
            var response = await _authService.DeleteAppUser(badgenumber);
            if (response == null)
            {
                return NotFound("No se pudo eliminar el usuario por que no existe");
            }
            if (!response.Succeeded)
            {
                return BadRequest($"Algo salió mal. {response.Errors.FirstOrDefault().Description}");
            }
            return Ok("El usuario fue eliminado exitosamente.");
        }

        [HttpPost("ConvertUsersinfoIntoAppUsers")]
        [Authorize(Roles="admin")]
        public async Task<IActionResult> CreateAppUsersFromExistingUserinfos()
        {
            var userinfosValidos = await _userinfoRepo.GetUserinfosValidosAppUser();
            if (userinfosValidos == null || userinfosValidos.Count == 0)
            {
                return BadRequest("No hay empleados que cumplan los requisitos para ser usuarios de la app.");
            }
            IdentityResult? result = null;
            try
            {
                result = await _authService.CreateAppUsersFromExistingUserinfos(userinfosValidos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if(result == null )
            {
                return BadRequest("Sí hay empleados pero no se pudo hacerlos usuarios de la app");
            }
            if(result.Succeeded == false)
            {
                return BadRequest($"Error: {result.Errors.FirstOrDefault().Description}");
            }
            return Ok("Los empleados que cumplían los requisitos, fueron creados como usuarios de la app.");
        }

        [HttpDelete("DeleteUserinfo")]
        [Authorize(Roles = "th, admin")]
        public async Task<IActionResult> DeleteUserinfo(string badgenumber)
        {
            //  Primero verifica que existan el Userinfo y el ApplicationUser
            bool existeUserinfo = await _userinfoRepo.ExisteUserinfo(badgenumber);
            bool? existeAppUser = await _authService.ExisteAppUser(badgenumber);
            if (existeUserinfo == false || existeAppUser == null || existeAppUser == false)
            {
                return NotFound("No se pudo eliminar el usuario por que no existe");
            }            

            // Luego, elimina el ApplicationUser en primer lugar
            var response = await _authService.DeleteAppUser(badgenumber);
            if (response == null)
            {
                return NotFound("No se pudo eliminar el usuario(app) por que no existe");
            }
            if (!response.Succeeded)
            {
                return BadRequest($"Algo salió mal. {response.Errors.FirstOrDefault().Description}");
            }

            // Finalmente elimina el userinfo
            var eliminaUserinfo = await _userinfoRepo.EliminaUserinfo(badgenumber);
            if (eliminaUserinfo == false)
            {
                return BadRequest($"No se pudo eliminar el usuario(info) {badgenumber}");
            }

            return Ok("El usuario fue eliminado exitosamente.");
        }

        [HttpPut("ChangePassword")]
        [Authorize(Roles="user")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            var currentAppUser = await GetCurrentAppUser();
            if (currentAppUser == null)
            {
                return BadRequest($"Algo salió muy mal.");
            }
            var response = await _authService.ChangePassword(currentAppUser.UserName, changePassword);
            if (response == null)
            {
                _logger.LogError("Error al querer cambiar el password");
                return BadRequest("Error al querer cambiar el password");
            }
            if (!response.Succeeded)
            {
                return BadRequest($"Algo salió mal. {response.Errors.FirstOrDefault().Description}");
            }
            return Ok("Se cambió el password.");
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshToken(RefreshTokenModel refreshModel)
        {
            _logger.LogInformation("Refresh called");
            var loginResult = await _authService.RefreshToken(refreshModel);
            if (loginResult.IslogedIn)
            {

                _logger.LogInformation("Refresh succeeded");
                return Ok(loginResult);
            }
            return Unauthorized($"Usuario no autorizado, token expiró.\nRefreshToken:{loginResult.RefreshToken}\nJwtToken:{loginResult.JwtToken}");
        }

        [Authorize]
        [HttpDelete("Revoke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Revoke()
        {
            _logger.LogInformation("Revoke called");

            var username = HttpContext.User.Identity?.Name;
            if (username == null)
            {
                return Unauthorized();
            }

            var loginUsernameResult = await _authService.Revoke(username);
            if (loginUsernameResult.IslogedIn == false)
            {
                return Unauthorized();
            }
            return Ok("Se revocó el token");
        }

    }
}
