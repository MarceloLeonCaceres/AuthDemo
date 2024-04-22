using DataRepository.Interfaces.AuthAppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models.Entities.AuthAppUser;

namespace DataRepository.Implementations.AuthAppUser
{
    public class RolesRepo(UserManager<ApplicationUser> userManager,
            RoleManager<Role> roleManager,
            ILogger<RolesRepo> logger,
            IConfiguration config) : IRolesRepo
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<Role> _roleManager = roleManager;
        private readonly ILogger<RolesRepo> _logger = logger;
        private readonly IConfiguration _config = config;


        public async Task<IdentityResult> CreateRole(string roleName)
        {
            var roleResult = await _roleManager.CreateAsync(new Role(roleName));
            return roleResult;
        }

        public async Task<List<ApplicationUser>> GetAllAppUsers()
        {
            var appUsers = await _userManager.Users.ToListAsync();
            return appUsers;
        }

        public async Task<List<string>> GetAppUserRoles(string username)
        {
            // Revisar si el usuario existe
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                _logger.LogInformation($"Usuario {username} no existe");
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            return (List<string>)roles;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<IdentityResult?> AddUserToRole(string username, string roleName)
        {
            // Revisar si el usuario existe
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                _logger.LogInformation($"Usuario {username} no existe.");
                return null;
            }
            // Revisar si el rol existe
            var rol = await _roleManager.FindByNameAsync(roleName);
            if (rol == null)
            {
                _logger.LogInformation($"El rol {roleName} no existe.");
                return null;
            }
            // Asigna el rol al empleado
            var result = await _userManager.AddToRoleAsync(appUser, roleName);
            return result;
        }
        public async Task<IdentityResult?> RemoveAppUserFromRole(string username, string roleName)
        {
            // Revisar si el usuario existe
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                _logger.LogInformation($"Usuario {username} no existe.");
                return null;
            }
            // Revisar si el rol existe
            var rol = await _roleManager.FindByNameAsync(roleName);
            if (rol == null)
            {
                _logger.LogInformation($"El rol {roleName} no existe.");
                return null;
            }
            // Quita el rol al empleado
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result;
        }

        public async Task<bool> RoleExist(string roleName)
        {

            // Revisar si el rol existe
            var rol = await _roleManager.FindByNameAsync(roleName);
            if (rol == null)
            {
                _logger.LogInformation($"El rol {roleName} no existe.");
                return false;
            }
            return true;
        }
    }
}
