﻿namespace WebApiJwtIdentity.Models
{
    public class RefreshTokenModel
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
