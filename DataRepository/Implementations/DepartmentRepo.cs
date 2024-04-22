using DataRepository.Interfaces;
using EfData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Models.Entities;

namespace DataRepository.Implementations
{
    public class DepartmentRepo(AppDbContext context, 
        ILogger<DepartmentRepo> logger ) : IDepartmentRepo
    {

        public async Task<List<Department>?> GetDepartments()
        {
            var deptos = await context.Departments.ToListAsync();
            return deptos;
        }
        public async Task<Department?> GetDepartmentById(int id)
        {
            return await context.Departments.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DeptoUsersDto>?> GetSubDepartments(int deptId, int otAdmin)
        {
            bool existeDepto = await context.Departments.AnyAsync(d => d.Id == deptId);
            if (existeDepto == false)
            {
                return null;
            }

            if(otAdmin == 1)
            {
                var depto = await context.Departments.Where(d => d.Id == deptId).Take(1).Select(d => new DeptoUsersDto
                {
                    Id = d.Id,
                    DeptName = d.DeptName,
                    Userinfos = d.Userinfos.Select(u => new UserinfoBNDto { Badgenumber = u.Badgenumber, Name = u.Name }).ToList()
                }).ToListAsync();

                if (depto is null || depto.Count == 0)
                {
                    return null;
                }
                return depto;
            }
            else if(otAdmin == 3)
            {
                var deptos = await context.Departments.Where(d => d.Id > 0).Select(d => new DeptoUsersDto
                {
                    Id = d.Id,
                    DeptName = d.DeptName,
                    Userinfos = d.Userinfos.Select(u => new UserinfoBNDto { Badgenumber = u.Badgenumber, Name = u.Name }).ToList()
                }).ToListAsync();

                if (deptos is null || deptos.Count == 0)
                {
                    return null;
                }
                
                return deptos;
            }
            else
            {
                var listaDeptos = await context.Departments.FromSqlInterpolated(@$"EXEC [SubDepartamentos] {deptId}")
                        .IgnoreQueryFilters().ToListAsync();
                if (listaDeptos == null || listaDeptos.Count == 0)
                {
                    return null;
                }
                List<int> listIds = listaDeptos.Select(d => d.Id).ToList();

                var subdeptos = await context.Departments.Where(d => listIds.Contains(d.Id)).Select(d => new DeptoUsersDto
                 {
                     Id = d.Id,
                     DeptName = d.DeptName,
                     Userinfos = d.Userinfos.Select(u => new UserinfoBNDto { Badgenumber = u.Badgenumber, Name = u.Name }).ToList()
                 }).ToListAsync();
                return subdeptos;
            }
        }


        public async Task<DeptoUsersDto?> GetDepartmentWithUsers(int deptId)
        {
            bool existeDepto = await context.Departments.AnyAsync(d => d.Id == deptId);
            if(existeDepto == false)
            {
                return null;
            }

            //  Con DTOs, es chévere y más eficiente que con AutoMapper
            var deptos = await context.Departments.Where(d => d.Id == deptId).Take(1).Select(d => new DeptoUsersDto
            {
                Id = d.Id,
                DeptName = d.DeptName,
                Userinfos = d.Userinfos.Select(u => new UserinfoBNDto { Badgenumber = u.Badgenumber, Name = u.Name }).ToList()
            }).ToListAsync();
           
            if(deptos is null || deptos.Count == 0)
            {
                return null;
            }
            return deptos[0];

        }
        public async Task<List<DepartmentWithUsers>?> GetDepartmentsWithUsers()
        {
            return await context.Departments.Where(d => d.Id > 0).Include(d => d.Userinfos)
                .Select(d => new DepartmentWithUsers
                {
                    DeptName = d.DeptName,
                    UsersNames = d.Userinfos.Select(u => u.Name).ToList(),
                }).AsNoTracking().ToListAsync();
        }
        public async Task<Department?> CreateDepartment(DeptoCreateDto deptoDto)
        {
            bool existePadre = await context.Departments.AnyAsync(d => d.Id == deptoDto.IdPadre);
            if (!existePadre)
            {
                return null;
            }
            Department newDepto = deptoDto.ToDepartmentFromCreate();
            try
            {
                await context.Departments.AddAsync(newDepto);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return newDepto;
        }

        public async Task<Department?> UpdateDepartment(DeptoUpdateDto updatedDepto)
        {
            var existingDepto = await context.Departments.SingleOrDefaultAsync(d => d.Id == updatedDepto.Id);
            if (existingDepto == null)
            {
                return null;
            }
            existingDepto.DeptName = updatedDepto.DeptName;
            await context.SaveChangesAsync();
            return existingDepto;
        }
        public async Task<Department?> DeleteDepartment(int id)
        {
            var existingDepto = await context.Departments.SingleOrDefaultAsync(d => d.Id == id);
            if (existingDepto == null || existingDepto.IdPadre == 0)
            {
                return null;
            }
            context.Departments.Remove(existingDepto);
            await context.SaveChangesAsync();
            return existingDepto;
        }
        public async Task<bool> ExistDepartment(int id)
        {
            return await context.Departments.AnyAsync(d => d.Id == id);
        }
    }
}
