using ApiProperJwt3.Controllers.Auth;
using DataRepository.Interfaces;
using DataRepository.Interfaces.AuthAppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.AuthAppUser;
using Models.Entities;
using System.Security.Claims;

namespace ApiProperJwt3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentRepo departmentRepo, 
        IAuthService authService, 
        ILogger<DepartmentController> logger) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly ILogger<DepartmentController> _logger = logger;

        private async Task<AppUserViewDto?> GetCurrentAppUser()
        {
            var badge = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (badge == null) { return null; }
            var appUser = await _authService.GetAppUserByUsername(badge);
            return appUser;
        }

        [HttpGet("GetDeptosUsersByAdmin")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DeptoUsersDto>>> GetDeptosUsersByAdmin()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var otAdmin = User.Claims.FirstOrDefault(c => c.Type == "OtAdmin")?.Value;
            var deptId = User.Claims.FirstOrDefault(c => c.Type == "DeptId")?.Value;
            if(otAdmin is null || deptId is null)
            {
                return NotFound("No se encontraron los privilegios del usuario.");
            }
                        
            var result = await departmentRepo.GetSubDepartments(int.Parse(deptId.ToString()), int.Parse(otAdmin.ToString()));
            return Ok(result);
        }

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

        [HttpGet("GetDepartmentByIdWithUsers({id}:int)")]
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
