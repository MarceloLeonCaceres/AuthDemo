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
