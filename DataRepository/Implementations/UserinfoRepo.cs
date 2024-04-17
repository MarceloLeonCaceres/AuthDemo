using DataRepository.Interfaces;
using EfData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Models.DTOs;
using Models.DTOs.AuthAppUser;
using Models.Entities;
using Models.Entities.Enums;
using Models.Mappers;

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
                EsAppUser = u.AppUser != null
            }).ToListAsync();
            return userinfos;
        }

        public async Task<UserinfoDto?> GetUserinfoByUserIdAsync(int userid)
        {
            var userinfo = await context.Usersinfo
                .Include(u => u.Department)
                .SingleAsync(u => u.UserinfoId == userid);

            UserinfoDto userDto = userinfo.ToUserinfoDto();
            if (userinfo == null)
            {
                logger.LogInformation($"Usuario con id {userid} no existe.");
                return null;
            }
            return userDto;
        }

        public async Task<Userinfo?> GetUserinfoByBadgenumberAsync(string badgenumber)
        {
            bool existeUserinfo = await context.Usersinfo.AnyAsync(u => u.Badgenumber == badgenumber);
            if(existeUserinfo == false)
            {
                logger.LogInformation($"Usuario con código {badgenumber} no existe.");
                return null;
            }
            var userinfo = await context.Usersinfo
                .Include(u => u.Department)
                .FirstAsync(u => u.Badgenumber == badgenumber);
            if (userinfo == null)
            {
                logger.LogInformation($"Usuario (d) con código {badgenumber} no existe.");
                return null;
            }
            return userinfo;
        }
        public async Task<List<Userinfo>> GetUsersinfoByDeptAsync(int deptId)
        {
            var userinfos = await context.Usersinfo
                .Include(u => u.Department)
                .Where(u => u.DepartmentId == deptId)
                .AsNoTracking()
                .ToListAsync();
            return userinfos;
        }

        //public async Task<List<SelectUserDeptoDto>?> GetUsersinfoSeleccionables(int deptId, int otAdmin)
        public async Task<List<Userinfo>?> GetUsersinfoSeleccionables(int deptId, int otAdmin)
        {
            List<Userinfo>? userinfos;
            if(otAdmin == 1)
            {
                userinfos = await context.Usersinfo
                .Include(u => u.Department)
                .Where(u => u.DepartmentId == deptId)
                .AsNoTracking()
                .ToListAsync();
                //return userinfos;
            }
            else if (otAdmin == 3)
            {
                userinfos = await context.Usersinfo
                .Include(u => u.Department)
                .Where(u => u.DepartmentId > 0)
                .AsNoTracking()
                .ToListAsync();
                //return userinfos;
            }
            else
            {
                var listaDeptos = await context.Departments.FromSqlInterpolated(@$"EXEC [SubDepartamentos] {deptId}")
                    .IgnoreQueryFilters().ToListAsync();
                List<int> list = listaDeptos.Select(d => d.Id).ToList();
                userinfos = await context.Usersinfo
                    .Where(u => list.Contains(u.DepartmentId)).ToListAsync());
            }
            return null;
        }

        public async Task<Userinfo?> CreateUserinfoAsync(UserinfoCreateFromBiometricoDto createUserinfo)
        {
            var deptoRaiz = await context.Departments.FirstOrDefaultAsync(d => d.IdPadre == 0);
            if (deptoRaiz == null)
            {
                logger.LogInformation($"No existe el departamento indicado.");
                return null;
            }
            var userinfo = new Userinfo()
            {
                Badgenumber = createUserinfo.Badgenumber,
                Name = createUserinfo.Name,
                DepartmentId = deptoRaiz.Id
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

        public async Task<Userinfo?> UpdateUserinfoFromAppUser(CreateAppUserDeCeroDto createAppUserDeCero)
        {
            bool existeDepto = await context.Departments.AnyAsync(d => d.Id == createAppUserDeCero.DepartmentId);
            if (existeDepto == false)
            {
                logger.LogInformation($"No existe el departamento indicado");
                return null;
            }
            var userinfoNuevo = createAppUserDeCero.ToUserinfo();            
            try
            {
                var userinfoExistente = await context.Usersinfo
                .SingleAsync(u => u.Badgenumber == createAppUserDeCero.Badgenumber);
                if (userinfoExistente is null)
                {
                    await context.Usersinfo.AddAsync(userinfoNuevo);
                    await context.SaveChangesAsync();
                    return userinfoNuevo;
                }
                else
                {
                    userinfoExistente.DepartmentId = createAppUserDeCero.DepartmentId;
                    userinfoExistente.Email = createAppUserDeCero.Email;
                    userinfoExistente.Name = createAppUserDeCero.Name;
                    userinfoExistente.SSN = createAppUserDeCero.SSN;
                    await context.SaveChangesAsync();
                    return userinfoExistente;
                }
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
                .SingleOrDefaultAsync(u => u.Badgenumber == badgenumber);
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
