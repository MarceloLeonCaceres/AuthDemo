using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwtIdentity.Models;
using WebApiJwtIdentity.Services;

namespace WebApiJwtIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] LoginUser user)
        {
            _logger.LogInformation("Register called");

            if(await _authService.RegisterUser(user))
            {
                return Ok("Registered successfully");
            }
            return BadRequest("Couldn't register this user");
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            _logger.LogInformation("Login called.");

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loginResult = await _authService.Login(user);
            if(loginResult.IslogedIn)
            {
                _logger.LogInformation("Login suceeded");
                return Ok(loginResult);
            }
            return Unauthorized("Usuario o password incorrectos");
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
            if(username == null)
            {
                return Unauthorized();
            }
            
            var loginUsernameResult = await _authService.Revoke(username);
            if(loginUsernameResult.IslogedIn == false)
            {
                return Unauthorized();
            }
            return Ok("Se revocó el token");
        }

    }
}
