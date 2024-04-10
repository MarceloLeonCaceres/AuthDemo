using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace WebApiJwtIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "You hit Test Controller";
        }

        [HttpGet("AuthorizedTest")]
        [Authorize]
        public IActionResult AuthorizedTest()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if(authorizationHeader is null)
            {
                return Unauthorized("Not Authenticated yet");
            }
            else
            {
                string jwtTokenString = authorizationHeader.Replace("Bearer ", "");

                var jwt = new JwtSecurityToken(jwtTokenString);

                var response = $"Authenticated!{Environment.NewLine}";

                if(jwt.ValidTo > DateTime.Now)
                {
                    response += "Token is valid.";
                }
                else
                {
                    response += "Token expired.";
                }

                response += $"{Environment.NewLine}Exp Time: {jwt.ValidTo.ToLongTimeString()}, Time:" +
                    $"{DateTime.Now.ToLongTimeString()}";
                return Ok(response);
            }
        }
    }
}
