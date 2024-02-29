using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiJwtIdentity.Models;

namespace WebApiJwtIdentity.Contexts
{
    public class AuthDemoDbContext : IdentityDbContext
    {
        public AuthDemoDbContext(DbContextOptions options):base(options)
        {       
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<ExtendedIdentityUser> ExtendedIdentityUsers { get; set; }
    }
}
