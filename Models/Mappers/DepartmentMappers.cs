using Models.DTOs;
using Models.Entities;

namespace Models.Mappers
{
    public static class DepartmentMappers
    {
        public static DeptoUpdateDto ToUpdateDto(this Department department)
        {
            return new DeptoUpdateDto
            {
                Id = department.Id,
                DeptName = department.DeptName
            };
        }

        public static Department ToDepartmentFromCreate(this DeptoCreateDto deptoDto)
        {
            return new Department()
            {
                DeptName = deptoDto.DeptName,
                IdPadre = deptoDto.IdPadre,
            };
        }

        public static DeptoDto ToDto(this Department department)
        {
            return new DeptoDto()
            {
                Id = department.Id,
                DeptName = department.DeptName,
                IdPadre = department.IdPadre
            };
        }

    }
}
