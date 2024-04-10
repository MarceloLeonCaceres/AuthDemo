using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.AuthAppUser
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPwd { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "La nueva contraseña debe tener al menos 10 caracteres")]
        public string NewPwd { get; set; }
    }
}
