namespace Models.Entities.AuthAppUser
{
    public class TokenResponse
    {
        public bool IslogedIn { get; set; } = false;
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
