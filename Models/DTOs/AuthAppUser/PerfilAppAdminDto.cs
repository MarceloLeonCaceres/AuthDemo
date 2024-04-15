using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.AuthAppUser
{
    public class PerfilAppAdminDto
    {

        [Required]
        [Range(0, 3, ErrorMessage = "Este código debe estar entre 0 y 3")]
        public int OtAdmin { get; set; }
        [Required]
        public int DeptId { get; set; }

        public bool RolTh { get; set; }
        public bool RolPlanificador { get; set; }
        public bool RolSupervisorMR { get; set; }
        public bool RolSupervisorPermisos { get; set; }
        public bool RolVisorReportes { get; set; }
        public bool RolAdmin { get; set; }

    }
}
