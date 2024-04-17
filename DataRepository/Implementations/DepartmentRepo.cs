using DataRepository.Interfaces;
using EfData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Models.Entities;

namespace DataRepository.Implementations
{
    public class DepartmentRepo(AppDbContext context, ILogger<DepartmentRepo> logger) : IDepartmentRepo
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

//        public async Task<List<int>> GetSubDepartments(int deptId)
//        {
//            var listaDeptos = await context.Departments.FromSqlInterpolated(@$"WITH SubDepartamentos (Id, deptName, idPadre)
//AS    (
//SELECT Id, deptName, 0 FROM departments WHERE Id = {deptId} 
//UNION ALL                
//SELECT D.Id, D.deptName, D.idPadre FROM departments D inner join SubDepartamentos Sub on Sub.Id = D.idPadre 
//)
//Select  Id From SubDepartamentos");
//            List<int> list = new List<int>();
//            foreach(var item in listaDeptos)
//            {
//                list.Add(int.Parse(item.Id));
//            }
//            return list;
//        }
        public async Task<DepartmentWithUsers?> GetDepartmentWithUsers(int deptId)
        {
            bool existeDepto = await context.Departments.AnyAsync(d => d.Id == deptId);
            if(existeDepto == false)
            {
                return null;
            }

            var deptos = await context.Departments.Include(d => d.Userinfos).Where(d => d.Id == deptId)
                .Select(d => new DepartmentWithUsers
            {
                DeptName = d.DeptName,
                UsersNames = d.Userinfos.Select(u => u.Name).ToList(),
            }).AsNoTracking().ToListAsync();

            return deptos[0];

            //return await context.Departments.SingleOrDefault(d => d.Id == deptId).Include(d => d.Userinfos)
            //    .Select(d => new DepartmentWithUsers
            //    {
            //        DeptName = d.DeptName,
            //        UsersNames  = d.Userinfos.Select(u => u.Name).ToList(),
            //    }).AsNoTracking().ToListAsync();
        }
        public async Task<List<DepartmentWithUsers>?> GetDepartmentsWithUsers()
        {
            return await context.Departments.Include(d => d.Userinfos)
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
            if (existingDepto == null)
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
