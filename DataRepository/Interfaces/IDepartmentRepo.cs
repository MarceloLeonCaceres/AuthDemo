using Models.DTOs;
using Models.Entities;

namespace DataRepository.Interfaces
{
    public interface IDepartmentRepo
    {
        Task<List<Department>?> GetDepartments();
        Task<Department?> GetDepartmentById(int id);
        Task<Department?> CreateDepartment(DeptoCreateDto deptoDto);
        Task<Department?> UpdateDepartment(DeptoUpdateDto updatedDepto);
        Task<Department?> DeleteDepartment(int id);
        Task<bool> ExistDepartment(int id);
    }
}
