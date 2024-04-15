using DataRepository.Interfaces;
using DataRepository.Interfaces.AuthAppUser;
using EfData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;
using Models.Mappers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DataRepository.Implementations.AuthAppUser
{
    public class AuthService(
        AppDbContext context,
        UserManager<AppUser> userManager,
        RoleManager<Role> roleManager,
        IUserinfoRepo userinfoRepo,
        IConfiguration config,
        ILogger<AuthService> logger) : IAuthService
    {


        public async Task<List<AppUserViewDto>?> GetAllAppUsers()
        {
            var users = await userManager.Users.ToListAsync();
            if (users == null || users.Count == 0)
            {
                return null;
            }
            var appUserViewDto = users.Select(u => u.ToAppUserViewDto()).ToList();
            return appUserViewDto;
        }

        public async Task<AppUserViewDto?> GetAppUserByUsername(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user is null)
            {
                return null;
            }
            var userDto = user.ToAppUserViewDto();
            return userDto;
        }

        public async Task<List<AppUserProfileViewDto>?> GetAppUsersProfileView()
        {
            var users = await userManager.Users
                                .Include(u => u.AppUserRoles)
                                .ThenInclude(ur => ur.Role)
                                .Select(u => new AppUserProfileViewDto
                                {
                                    //Badgenumber = u.Badgenumber,
                                    //OtAdmin = u.OtAdmin,
                                    UserName = u.UserName,
                                    Email = u.Email,
                                    Roles = u.AppUserRoles.Select(r => r.Role.Name).ToList()
                                })
                                .AsNoTracking()
                                .ToListAsync();
            return users;
        }

        public async Task<IdentityResult?> CreateAppAdmin(CreateAppAdminDto createAppAdmin)
        {
            var appUserExistente = await userManager.FindByNameAsync(createAppAdmin.UserName);
            if (appUserExistente != null)
            {
                logger.LogWarning($"El usuario {createAppAdmin.UserName} ya existe.");
                return null;
            }

            bool existeDepto = await context.Departments.AnyAsync(d => d.Id == createAppAdmin.DeptId);
            if (existeDepto == false)
            {
                logger.LogInformation($"No existe el departamento indicado");
                return null;
            }
            
            AppUser newAppUser = createAppAdmin.ToAppUserFromAppAdmin();
            var createAdmin = await userManager.CreateAsync(newAppUser, createAppAdmin.Password);
            if (createAdmin.Succeeded == false)
            {
                logger.LogWarning("No se pudo crear al usuario");
                return createAdmin;
            }

            var result = await SetPerfilAppUser(newAppUser, createAppAdmin);
            logger.LogInformation("Se creó al usuario con su perfil");
            return result;
        }
        public async Task<IdentityResult?> CreateAppUser(CreateAppUserDeCeroDto createAppUserDeCero)
        {
            var appUserExistente = await userManager.FindByNameAsync(createAppUserDeCero.Badgenumber);
            if (appUserExistente != null)
            {
                logger.LogWarning($"El usuario {createAppUserDeCero.Badgenumber} ya existe.");
                return null;
            }

            bool existeDepto = await context.Departments.AnyAsync(d => d.Id == createAppUserDeCero.DepartmentId);
            if (existeDepto == false)
            {
                logger.LogInformation($"No existe el departamento indicado");
                return null;
            }
            var userinfoNuevo = createAppUserDeCero.ToUserinfo();
            
            AppUser newAppUser = createAppUserDeCero.ToAppUserFromCreate();
            var userinfoExistente = await context.Usersinfo.SingleOrDefaultAsync(u => u.Badgenumber == createAppUserDeCero.Badgenumber);

            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var createUser = await userManager.CreateAsync(newAppUser, createAppUserDeCero.SSN);
                if (createUser.Succeeded == false)
                {
                    logger.LogWarning("No se pudo crear al usuario");
                    return createUser;
                }

                var result = await userManager.AddToRoleAsync(newAppUser, "user");

                if (userinfoExistente is null)
                {
                    userinfoNuevo.AppUser = newAppUser;
                    await context.Usersinfo.AddAsync(userinfoNuevo);
                }
                else
                {
                    userinfoExistente.AppUser = newAppUser;
                    userinfoExistente.DepartmentId = createAppUserDeCero.DepartmentId;
                    userinfoExistente.Email = createAppUserDeCero.Email;
                    userinfoExistente.Name = createAppUserDeCero.Name;
                    userinfoExistente.SSN = createAppUserDeCero.SSN;
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                logger.LogInformation("Se creó al usuario con su perfil");
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<IdentityResult?> SetPerfilAppUser(AppUser appUser, PerfilAppAdminDto perfilAppUser)
        {
            IdentityResult? result = null;

            List<Claim> claims = (List<Claim>)await userManager.GetClaimsAsync(appUser);
            if (claims != null)
            {
                result = await userManager.RemoveClaimsAsync(appUser, claims);
            }
            if (perfilAppUser.OtAdmin > 0)
            {
                result = await userManager.AddClaimAsync(appUser, new Claim("OtAdmin", perfilAppUser.OtAdmin.ToString()));
                result = await userManager.AddClaimAsync(appUser, new Claim("DeptId", perfilAppUser.DeptId.ToString()));
            }

            // Asignar roles
            List<(bool Tiene, string RolName)> TieneRoles = RolesDelAppUser(perfilAppUser);
            try
            {
                foreach (var tieneRol in TieneRoles)
                {
                    result = await userManager.RemoveFromRoleAsync(appUser, tieneRol.RolName);
                }
                foreach (var tieneRol in TieneRoles)
                {
                    if (tieneRol.Tiene)
                    {
                        result = await userManager.AddToRoleAsync(appUser, tieneRol.RolName);
                    }
                }
            }
            catch (Exception)
            {
                logger.LogError("No se pudo aplicar el cambio de perfil solicitado.");
                return null;
            }
            return result;
        }

        private static List<(bool Tiene, string RolName)> RolesDelAppUser(PerfilAppAdminDto perfilAppUser)
        {
            List<(bool Tiene, string RolName)> TieneRoles = new();
            TieneRoles.Add((perfilAppUser.RolAdmin, "admin"));
            TieneRoles.Add((perfilAppUser.RolSupervisorMR, "supervisorMR"));
            TieneRoles.Add((perfilAppUser.RolSupervisorPermisos, "supervisorPermisos"));
            TieneRoles.Add((perfilAppUser.RolVisorReportes, "visorReportes"));
            TieneRoles.Add((perfilAppUser.RolTh, "th"));
            TieneRoles.Add((perfilAppUser.RolPlanificador, "planificador"));

            return TieneRoles;
        }

        public async Task<IdentityResult?> UpdatePerfilAppUser(string badgenumber, PerfilAppAdminDto newPerfil)
        {

            var appUser = await userManager.FindByNameAsync(badgenumber);
            if (appUser is null)
            {
                logger.LogWarning($"El usuario {badgenumber} no existe.");
                return null;
            }

            IdentityResult? result = null;

            List<Claim> claims = (List<Claim>)await userManager.GetClaimsAsync(appUser);
            if (claims != null && claims.Count > 0)
            {
                Claim claimOtadmin = claims[0];
                result = await userManager.RemoveClaimAsync(appUser, claimOtadmin);
            }
            if (newPerfil.OtAdmin > 0)
            {
                result = await userManager.AddClaimAsync(appUser, new Claim("OtAdmin", newPerfil.OtAdmin.ToString()));
            }

            // Asignar roles
            List<(bool Tiene, string RolName)> TieneRoles = RolesDelAppUser(newPerfil);
            try
            {
                foreach (var tieneRol in TieneRoles)
                {
                    result = await userManager.RemoveFromRoleAsync(appUser, tieneRol.RolName);
                }
                foreach (var tieneRol in TieneRoles)
                {
                    if (tieneRol.Tiene)
                    {
                        result = await userManager.AddToRoleAsync(appUser, tieneRol.RolName);
                    }
                }
            }
            catch (Exception)
            {
                logger.LogError("No se pudo aplicar el cambio de perfil solicitado.");
                return null;
            }
            return result;

        }
        public async Task<IdentityResult?> DeleteAppUser(string badgenumber)
        {
            var existingAppUser = await userManager.Users.SingleOrDefaultAsync(u => u.UserName == badgenumber);
            if (existingAppUser == null)
            {
                logger.LogWarning("Usuario no encontrado para eliminarlo.");
                return null;
            }
            var existingUserinfo = await userinfoRepo.GetUserinfoByBadgenumberAsync(badgenumber);
            if (existingUserinfo != null)
            {
                existingUserinfo.AppUser = null;
                await context.SaveChangesAsync();
            }
            try
            {
                var result = await userManager.DeleteAsync(existingAppUser);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool?> ExisteAppUser(string username)
        {
            var result = await userManager.FindByNameAsync(username);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<TokenResponse> Login(LoginDto user)
        {
            var response = new TokenResponse();
            var identityUser = await userManager.FindByNameAsync(user.Username);
            if (identityUser is null)
            {
                return response;
            }

            if (await userManager.CheckPasswordAsync(identityUser, user.Password) == false)
            {
                return response;
            }

            response.IslogedIn = true;
            response.JwtToken = await this.GenerateTokenString(identityUser);
            response.RefreshToken = this.GenerateRefreshTokenString();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(1);
            await userManager.UpdateAsync(identityUser);

            return response;
        }
        public async Task<IdentityResult?> ChangePassword(string username, ChangePasswordDto changePwdDto)
        {
            var appUser = await userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return null;
            }
            var isChangeOk = await userManager.ChangePasswordAsync(appUser, changePwdDto.CurrentPwd, changePwdDto.NewPwd);
            return isChangeOk;
        }

        public async Task<TokenResponse> Revoke(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            var response = new TokenResponse();
            if (user is null)
            {
                return response;
            }
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
            response.IslogedIn = true;
            return response;
        }

        public async Task<TokenResponse> RefreshToken(RefreshTokenModel refreshModel)
        {
            var principal = GetPrincipalFromExpiredToken(refreshModel.JwtToken);

            var response = new TokenResponse();
            if (principal?.Identity?.Name is null)
            {
                return response;
            }

            var identityUser = await userManager.FindByNameAsync(principal.Identity.Name);

            if (identityUser is null || identityUser.RefreshToken != refreshModel.RefreshToken ||
                identityUser.RefreshTokenExpiry < DateTime.Now)
            {
                return response;
            }

            response.IslogedIn = true;
            response.JwtToken = await this.GenerateTokenString(identityUser);
            response.RefreshToken = this.GenerateRefreshTokenString();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.UtcNow.AddHours(1);
            await userManager.UpdateAsync(identityUser);

            return response;
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value));

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

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateTokenString(AppUser appUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var claimsPropias = await GetAllValidClaims(appUser);

            var securityToken = new JwtSecurityToken(
                claims: claimsPropias,
                expires: DateTime.Now.AddDays(1),
                issuer: config.GetSection("Jwt:Issuer").Value,
                audience: config.GetSection("Jwt:Audience").Value,
                signingCredentials: credentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        private async Task<List<Claim>> GetAllValidClaims(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, appUser.UserName)
            };

            // Getting los claims que tenemos asignados para el usuario
            var userClaims = await userManager.GetClaimsAsync((AppUser)appUser);
            claims.AddRange(userClaims);

            // Get el rol del usuario y agregarlo a los claims
            var userRoles = await userManager.GetRolesAsync((AppUser)appUser);
            foreach (var userRole in userRoles)
            {
                var role = await roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    var roleClaims = await roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }

    }
}
