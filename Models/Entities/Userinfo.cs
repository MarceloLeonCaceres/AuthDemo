﻿using Microsoft.EntityFrameworkCore;
using Models.DTOs.AuthAppUser;
using Models.Entities.AuthAppUser;
using Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    // [Index(nameof(Badgenumber), IsUnique = true)]
    public class Userinfo
    {
        [Key]
        public int UserinfoId { get; set; }
        [StringLength(maximumLength: 9)]
        public string Badgenumber { get; set; }
        public string Name { get; set; }
        public string? SSN { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public DateOnly? HiredDay { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId {  get; set; }
        public ApplicationUser? AppUser { get; set; }
        
    }
}
