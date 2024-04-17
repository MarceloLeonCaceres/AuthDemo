using DataRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace ApiProperJwt3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentRepo departmentRepo) : ControllerBase
    {
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var deptos = await departmentRepo.GetDepartments();
            if(deptos is null) 
            {
                return NotFound("No hay departamentos.");
            }
            return Ok(deptos);
        }

        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var depto = await departmentRepo.GetDepartmentById(id);
            if(depto is null)
            {
                return NotFound("No existe el departamento solicitado.");
            }
            return Ok(depto);
        }

        [HttpGet("GetDepartmentsWithUsers")]
        public async Task<IActionResult> GetDepartmentsWithUsers()
        {
            var deptosUsers = await departmentRepo.GetDepartmentsWithUsers();
            if (deptosUsers is null)
            {
                return NotFound("No existe el departamento solicitado.");
            }
            return Ok(deptosUsers);
        }

        [HttpGet("GetDepartmentByIdWithUsers")]
        public async Task<IActionResult> GetDepartmentWithUsers(int id)
        {
            var deptosUsers = await departmentRepo.GetDepartmentWithUsers(id);
            if (deptosUsers is null)
            {
                return NotFound("No existe el departamento solicitado.");
            }
            return Ok(deptosUsers);
        }
    }
}
