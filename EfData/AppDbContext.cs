using EfData.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.AuthAppUser;
using Models.Entities;
using Models.Entities.AuthAppUser;
using Models.Entities.Enums;

namespace EfData
{
    public class AppDbContext : IdentityDbContext<AppUser, Role, string,
        IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>,IdentityUserToken<string> >
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P102OJ1;Initial Catalog=WebApiIdentityProper3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Userinfo>(b =>
            {
                b.HasIndex(u => u.Badgenumber).IsUnique(true);
                b.Property(u => u.Badgenumber).HasMaxLength(9).IsRequired(true);
                b.HasIndex(u => u.Name).IsDescending(false);
                b.Property(u => u.Name).HasMaxLength(150).IsRequired(true);
                b.HasIndex(u => u.SSN).IsUnique(true);
                b.Property(u => u.SSN).HasMaxLength(10);
                b.Property(u => u.Email).HasMaxLength(150);
                b.Property(u => u.HiredDay).HasColumnType("date");
            });

            modelBuilder.Entity<Department>(b =>
            {
                b.Property(d => d.DeptName).HasMaxLength(150).IsRequired(true);
                b.Property(d => d.IdPadre).IsRequired(true);

                b.HasMany(d => d.Userinfos)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId)
                .IsRequired();
            });
                        
            modelBuilder.Entity<AppUser>(b =>
            {
                // Primary key
                b.HasKey( u => u.Id );

                // Indexes for "normalized" username and email, to allow efficient lookups
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                // b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                // Maps to the AspNetUsers table
                b.ToTable("AspNetUsers");

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                b.Property(u => u.PhoneNumber).IsUnicode(false).IsFixedLength(false).HasMaxLength(16);
                b.Property(u => u.PasswordHash).IsUnicode(false).IsFixedLength(false).HasMaxLength(90);
                b.Property(u => u.ConcurrencyStamp).IsUnicode(false).IsFixedLength(false).HasMaxLength(64).IsRequired(true);
                b.Property(u => u.SecurityStamp).IsUnicode(false).IsFixedLength(false).HasMaxLength(64).IsRequired(true);
                

                // The relationships between User and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each User can have many UserClaims
                //b.HasMany<TUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

                // Each User can have many UserLogins
                // b.HasMany<TUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

                // Each User can have many UserTokens
                // b.HasMany<TUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.AppUserRoles).WithOne(e => e.AppUser).HasForeignKey(ur => ur.UserId).IsRequired();
            });

            modelBuilder.Entity<Role>(b =>
            {
                // Primary key
                b.HasKey(r => r.Id);

                // Maps to the AspNetRoles table
                b.ToTable("AspNetRoles");

                // Limit the size of columns to use efficient database types
                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.AppUserRoles).WithOne(e => e.Role).HasForeignKey(ur => ur.RoleId).IsRequired();

                // Each Role can have many associated RoleClaims
                // b.HasMany<TRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            modelBuilder.Entity<AppUserRole>(b =>
            {
                // Primary key
                b.HasKey(r => new { r.UserId, r.RoleId });

                // Maps to the AspNetUserRoles table
                b.ToTable("AspNetUserRoles");
            });

            DataSeeding.Seed(modelBuilder);

        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Userinfo> Usersinfo { get; set; }

    }
}
