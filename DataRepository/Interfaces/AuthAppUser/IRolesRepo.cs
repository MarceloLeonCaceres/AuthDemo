using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.AuthAppUser;

namespace DataRepository.Interfaces.AuthAppUser
{
    public interface IRolesRepo
    {
        Task<List<ApplicationUser>> GetAllAppUsers();
        Task<List<string>> GetAppUserRoles(string username); 
        Task<List<Role>> GetRolesAsync();
        Task<IdentityResult?> AddUserToRole(string username, string roleName);
        Task<IdentityResult?> RemoveAppUserFromRole(string username, string roleName);
        Task<bool> RoleExist(string roleName);
        Task<IdentityResult> CreateRole(string roleName);
    }
}
