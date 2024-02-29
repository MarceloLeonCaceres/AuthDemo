namespace WebApiJwtIdentity.Models
{
    public class LoginResponse
    {
        public bool IslogedIn { get; set; } = false;
        public string JwtToken { get; set; }
        public string RefreshToken { get; internal set; }
    }
}
