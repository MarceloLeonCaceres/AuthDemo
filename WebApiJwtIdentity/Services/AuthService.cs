using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApiJwtIdentity.Models;

namespace WebApiJwtIdentity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<ExtendedIdentityUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<bool> RegisterUser(LoginUser user)
        {
            var identityUser = new ExtendedIdentityUser
            {
                UserName = user.Username,
                Email = user.Username
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }

        public async Task<LoginResponse> Login(LoginUser user)
        {
            var response = new LoginResponse();
            var identityUser = await _userManager.FindByEmailAsync(user.Username);
            if(identityUser is null)
            {
                return response;
            }

            if(await _userManager.CheckPasswordAsync(identityUser, user.Password) == false)
            {
                return response;
            }

            response.IslogedIn = true;
            response.JwtToken = this.GenerateTokenString(identityUser.Email);
            response.RefreshToken = this.GenerateRefreshTokenString();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(1);
            await _userManager.UpdateAsync(identityUser);

            return response;
        }

        public async Task<LoginResponse> Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var response = new LoginResponse();
            if(user is null)
            {
                return response;
            }
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            response.IslogedIn = true;
            return response;
        }

        public async Task<LoginResponse> RefreshToken(RefreshTokenModel refreshModel)
        {
            var principal = GetPrincipalFromExpiredToken(refreshModel.JwtToken);

            var response = new LoginResponse();
            if (principal?.Identity?.Name is null)
            {
                return response;
            }

            var identityUser = await _userManager.FindByNameAsync(principal.Identity.Name);

            if(identityUser is null || identityUser.RefreshToken != refreshModel.RefreshToken || 
                identityUser.RefreshTokenExpiry < DateTime.Now)
            {
                return response;
            }

            response.IslogedIn = true;
            response.JwtToken = this.GenerateTokenString(identityUser.Email);
            response.RefreshToken = this.GenerateRefreshTokenString();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.UtcNow.AddHours(1);
            await _userManager.UpdateAsync(identityUser);

            return response;
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var validation = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
            var claimPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
            return claimPrincipal;
        }

        private string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[64];

            using(var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        public string GenerateTokenString(string userName)
        {
            IEnumerable<Claim> claimsPropias = new List<Claim> { 
                new Claim(ClaimTypes.Email, userName),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var staticKey = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(staticKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            
            var securityToken = new JwtSecurityToken(
                claims: claimsPropias,
                expires: DateTime.Now.AddMinutes(1),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: credentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

    }
}
