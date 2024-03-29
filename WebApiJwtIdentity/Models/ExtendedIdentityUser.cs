﻿using Microsoft.AspNetCore.Identity;

namespace WebApiJwtIdentity.Models
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }

    }
}
