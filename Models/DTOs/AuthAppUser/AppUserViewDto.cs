using System.Reflection.Metadata.Ecma335;

namespace Models.DTOs.AuthAppUser
{
    public class AppUserViewDto
    {
        public string Badgenumber { get; set; }
        public int OtAdmin { get; set; }
        public int TipoEmpleado { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
