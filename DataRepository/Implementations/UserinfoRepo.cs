using DataRepository.Interfaces;
using EfData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Models.Entities;
using Models.Entities.Enums;

namespace DataRepository.Implementations
{
    public class UserinfoRepo(AppDbContext context, ILogger<UserinfoRepo> logger) : IUserinfoRepo
    {

        public async Task<List<UserinfoDto>?> GetUsersinfoAsync()
        {
            var userinfos = await context.Usersinfo.Select(u => new UserinfoDto
            {
                Badgenumber = u.Badgenumber,
                SSN = u.SSN,
                Name = u.Name,
                DeptName = u.Department.DeptName,
                Email = u.Email,
            }).ToListAsync();
            return userinfos;
        }

        public async Task<Userinfo?> GetUserinfoByUserIdAsync(int userid)
        {
            var userinfo = await context.Usersinfo
                .Include(u => u.Department)
                .SingleOrDefaultAsync(u => u.UserinfoId == userid);
            if (userinfo == null)
            {
                logger.LogInformation($"Usuario con id {userid} no existe.");
                return null;
            }
            return userinfo;
        }

        public async Task<Userinfo?> GetUserinfoByBadgenumberAsync(string badgenumber)
        {
            var userinfo = await context.Usersinfo
                .Include(u => u.Department)
                .FirstAsync(u => u.Badgenumber == badgenumber);
            if (userinfo == null)
            {
                logger.LogInformation($"Usuario con código {badgenumber} no existe.");
                return null;
            }
            return userinfo;
        }
        public async Task<List<Userinfo>> GetUsersinfoByDeptAsync(int deptId)
        {
            var userinfos = await context.Usersinfo
                .Include(u => u.Department)
                .Where(u => u.DepartmentId == deptId)
                .ToListAsync();
            return userinfos;
        }

        public async Task<Userinfo?> CreateUserinfoAsync(UserinfoCreateFromBiometricoDto createUserinfo)
        {
            var idDeptoRaiz = await context.Departments.FirstOrDefaultAsync(d => d.IdPadre == 0);
            if (idDeptoRaiz == null)
            {
                logger.LogInformation($"No existe el departamento indicado.");
                return null;
            }
            var userinfo = new Userinfo()
            {
                Badgenumber = createUserinfo.Badgenumber,
                Name = createUserinfo.Name,
                DepartmentId = idDeptoRaiz.Id
            };
            try
            {
                await context.Usersinfo.AddAsync(userinfo);
                await context.SaveChangesAsync();
                return userinfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Userinfo?> UpdateUserinfoAsync(Userinfo userinfo)
        {
            var userinfoEnBdd = await context.Usersinfo
                .Include(u => u.Department)
                .FirstAsync(u => u.Badgenumber == userinfo.Badgenumber);
            if (userinfo == null)
            {
                logger.LogInformation($"Error al Actualizar. Usuario con código {userinfo.Badgenumber} no existe.");
                return null;
            }

            userinfoEnBdd.Name = userinfo.Name;

            await context.SaveChangesAsync();
            return userinfoEnBdd;
        }

        public async Task<bool> EliminaUserinfo(string badgenumber)
        {
            var userinfo = await context.Usersinfo
                .FirstAsync(u => u.Badgenumber == badgenumber);
            if (userinfo == null)
            {
                logger.LogInformation($"Error al Eliminar. Usuario con código {badgenumber} no existe.");
                return false;
            }
            context.Usersinfo.Remove(userinfo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteUserinfo(string badgenumber)
        {
            var result = await context.Usersinfo.AnyAsync(u => u.Badgenumber == badgenumber);
            return result;
        }

    }
}
