using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.AuthAppUser
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
