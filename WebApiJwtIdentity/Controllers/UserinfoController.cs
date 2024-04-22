using DataRepository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using System.Security.Claims;

namespace ApiProperJwt3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserinfoController(IUserinfoRepo userinfoRepo) : ControllerBase
    {

        [HttpGet("GetUsersInfo")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUsersInfo()
        {
            var usersinfo = await userinfoRepo.GetUsersinfoAsync();
            if (usersinfo is null)
            {
                return NotFound("No hay usuarios");
            }
            return Ok(usersinfo);
        }

        [HttpGet("GetUserinfoByBadge")]
        public async Task<IActionResult> GetUserinfoByBadge(string badgenumber)
        {
            var userinfo = await userinfoRepo.GetUserinfoByBadgenumberAsync(badgenumber);
            if (userinfo is null)
            {
                return NotFound($"No hay el usuario de código {badgenumber}");
            }
            return Ok(userinfo);
        }

        [HttpGet("GetUsersInfoByDept")]
        public async Task<IActionResult> GetUsersByDept(int deptId)
        {
            var usersinfo = await userinfoRepo.GetUsersinfoByDeptAsync(deptId);
            if (usersinfo is null)
            {
                return NotFound("No hay usuarios en este departamento");
            }
            return Ok(usersinfo);
        }

        [HttpGet("GetUsersInfoByProfile")]
        [Authorize]
        public async Task<IActionResult> GetUsersInfoByProfile()
        {   
            var username = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var otadmin = User.Claims.FirstOrDefault(c => c.Type == "OtAdmin")?.Value;
            var deptId = User.Claims.FirstOrDefault(c => c.Type == "DeptId")?.Value;
            if (otadmin is null || deptId is null)
            {   
                // Solo envia el userinfo correspondiente del ApplicationUser logeado
                return NotFound("Algo salió mal");
            }
            // Envia los usersinfo disponibles segun el otadmin y el depto del AddAdmin logeado
            var respuesta = await userinfoRepo.GetUsersinfoSeleccionables(int.Parse(deptId), int.Parse(otadmin));
            return Ok(username);
        }

        [HttpPost("CreateUserinfo")]
        public async Task<IActionResult> CreateUserinfo(UserinfoCreateFromBiometricoDto createUserinfoDto)
        {
            var user = await userinfoRepo.CreateUserinfoAsync(createUserinfoDto);
            if(user is null)
            {
                return BadRequest("No se creó el usuario, revise los datos");
            }
            return Ok(user);
        }

        [HttpDelete("DeleteUserinfo")]
        public async Task<IActionResult> DeleteUserinfo(string badgenumber)
        {
            bool result = await userinfoRepo.EliminaUserinfo(badgenumber);
            if(result == false)
            {
                return NotFound("No se encontró este usuario.");
            }
            return Ok("El usuario fue eliminado exitosamente.");
        }
    }
}
