﻿// <auto-generated />
using System;
using EfData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240417205416_StoreProcedureSubDeptos")]
    partial class StoreProcedureSubDeptos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Entities.AuthAppUser.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .IsFixedLength(false);

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(90)
                        .IsUnicode(false)
                        .HasColumnType("varchar(90)")
                        .IsFixedLength(false);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .IsFixedLength(false);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .IsFixedLength(false);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "869f332e-a84d-4803-af9b-91b4c679ecb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "810a668e-ba83-4cda-8ae5-fd7e543ca22b",
                            Email = "Admin123@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN123",
                            PasswordHash = "AQAAAAIAAYagAAAAENX4If80rSGMYZUI5gOcOTr2dnG5EKhkiUlpGHwngpMEthC4RoVwv+yidMs33oU9uw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6ff662ac-2f01-43d5-bdde-c9ad2ba19827",
                            TwoFactorEnabled = false,
                            UserName = "Admin123"
                        },
                        new
                        {
                            Id = "0d52f835-94e1-409e-b180-4f370f40f98d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7052f5a1-6b6c-4158-bb35-308abc4fe714",
                            Email = "aprueba1@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "APRUEBA1@EXAMPLE.COM",
                            NormalizedUserName = "APRUEBA1",
                            PasswordHash = "AQAAAAIAAYagAAAAEMrh4S9M/VqxsLcdW91FOYDmaOH7MJTLyFrVmf8ep8bNzhtRPVNcHjgPQEpH0y5kCw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b48cb3b6-cb8b-4e6b-abb3-e4ecd85fec2f",
                            TwoFactorEnabled = false,
                            UserName = "Aprueba1"
                        },
                        new
                        {
                            Id = "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "599e2df0-f5aa-445c-964c-32abd2e7645c",
                            Email = "aprueba3@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "APRUEBA3@EXAMPLE.COM",
                            NormalizedUserName = "APRUEBA3",
                            PasswordHash = "AQAAAAIAAYagAAAAEO4y2ppfT55dOLxESBBV6PZYojxsA5n/z7QSgUU83DvdMzBh9wCwSBt5RXeihP38uQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9b1c7d0a-4db5-493b-8d9e-aa0c95f5f6e6",
                            TwoFactorEnabled = false,
                            UserName = "Aprueba3"
                        },
                        new
                        {
                            Id = "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "83dac0f3-e054-4cbb-add0-8eb07e1010ac",
                            Email = "planeador1@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "PLANEADOR1@EXAMPLE.COM",
                            NormalizedUserName = "PLANEADOR1",
                            PasswordHash = "AQAAAAIAAYagAAAAEP8wpnddFNcaJEXoNLgtv7V1hZWr412wF3HsWnBcKqXPkYh6C8QTOw6NEvGf0cZvfA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6aa43204-20cd-413a-bb72-259e98388e07",
                            TwoFactorEnabled = false,
                            UserName = "Planeador1"
                        },
                        new
                        {
                            Id = "22472f44-f29e-4317-ac81-966e5c4a6035",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8e4a1790-423a-4ade-8ddc-79d2bf5f3878",
                            Email = "thumano1@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "THUMANO1@EXAMPLE.COM",
                            NormalizedUserName = "THUMANO1",
                            PasswordHash = "AQAAAAIAAYagAAAAEAU6LvxbpTQn8MrnMGHT3kVxDMpMvDDgjmnB6uQ5W2y9SEBBIjSh5bGFsqwFWcVukA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e2bee33a-cbcb-4150-93ae-731a5cde0396",
                            TwoFactorEnabled = false,
                            UserName = "THumano1"
                        },
                        new
                        {
                            Id = "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "92eea465-2ee5-4118-bb6a-916a5edf5b90",
                            Email = "reporte1@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "REPORTE1@EXAMPLE.COM",
                            NormalizedUserName = "REPORTE1",
                            PasswordHash = "AQAAAAIAAYagAAAAEH4nZjzlOCShWaoc0WfrBxtnk6Zkv4qQ/yDTgmqSai8RSm6vO79fK4CG8dydEbq4EQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4e984034-7b01-4b44-8bd2-0c967f5013eb",
                            TwoFactorEnabled = false,
                            UserName = "Reporte1"
                        });
                });

            modelBuilder.Entity("Models.Entities.AuthAppUser.AppUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "869f332e-a84d-4803-af9b-91b4c679ecb9",
                            RoleId = "ab4cd34b-8232-4244-b459-cb150202c040"
                        },
                        new
                        {
                            UserId = "0d52f835-94e1-409e-b180-4f370f40f98d",
                            RoleId = "86e60536-b2ab-4ac5-85b8-e2afd8fe7058"
                        },
                        new
                        {
                            UserId = "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                            RoleId = "1b7d2e86-b210-4846-9530-16962a69af6d"
                        },
                        new
                        {
                            UserId = "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                            RoleId = "4899d69d-bfef-4a1b-972b-c66cc56b7a89"
                        },
                        new
                        {
                            UserId = "22472f44-f29e-4317-ac81-966e5c4a6035",
                            RoleId = "c8c2a86c-7c38-45e5-95ac-b067a19aea4f"
                        },
                        new
                        {
                            UserId = "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                            RoleId = "017ba3c7-6860-48fe-a066-fe005ae54521"
                        });
                });

            modelBuilder.Entity("Models.Entities.AuthAppUser.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ab4cd34b-8232-4244-b459-cb150202c040",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "4899d69d-bfef-4a1b-972b-c66cc56b7a89",
                            Name = "planificador",
                            NormalizedName = "PLANIFICADOR"
                        },
                        new
                        {
                            Id = "86e60536-b2ab-4ac5-85b8-e2afd8fe7058",
                            Name = "supervisorPermisos",
                            NormalizedName = "SUPERVISORPERMISOS"
                        },
                        new
                        {
                            Id = "1b7d2e86-b210-4846-9530-16962a69af6d",
                            Name = "supervisorMR",
                            NormalizedName = "SUPERVISORMR"
                        },
                        new
                        {
                            Id = "c8c2a86c-7c38-45e5-95ac-b067a19aea4f",
                            Name = "th",
                            NormalizedName = "TH"
                        },
                        new
                        {
                            Id = "bf52d74f-adb0-4a8a-b8fa-bb0141ab9a29",
                            Name = "user",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "017ba3c7-6860-48fe-a066-fe005ae54521",
                            Name = "visorReportes",
                            NormalizedName = "VISORREPORTES"
                        });
                });

            modelBuilder.Entity("Models.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IdPadre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeptName = "Empresa",
                            IdPadre = 0
                        },
                        new
                        {
                            Id = 2,
                            DeptName = "Financiero",
                            IdPadre = 1
                        },
                        new
                        {
                            Id = 3,
                            DeptName = "Ventas",
                            IdPadre = 1
                        },
                        new
                        {
                            Id = 4,
                            DeptName = "Talento Humano",
                            IdPadre = 1
                        },
                        new
                        {
                            Id = 5,
                            DeptName = "Marketing",
                            IdPadre = 3
                        });
                });

            modelBuilder.Entity("Models.Entities.Userinfo", b =>
                {
                    b.Property<int>("UserinfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserinfoId"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Badgenumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateOnly?>("HiredDay")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SSN")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserinfoId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("Badgenumber")
                        .IsUnique();

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Name");

                    b.HasIndex("SSN")
                        .IsUnique()
                        .HasFilter("[SSN] IS NOT NULL");

                    b.ToTable("Usersinfo");

                    b.HasData(
                        new
                        {
                            UserinfoId = 1,
                            Badgenumber = "1",
                            DepartmentId = 1,
                            Email = "gacero@example.com",
                            Name = "ACERO GLORIA"
                        },
                        new
                        {
                            UserinfoId = 2,
                            Badgenumber = "2",
                            DepartmentId = 1,
                            Email = "rbarcia@example.com",
                            Name = "BARCIA RUTH"
                        },
                        new
                        {
                            UserinfoId = 3,
                            Badgenumber = "3",
                            DepartmentId = 1,
                            Email = "elopez@example.com",
                            Name = "LOPEZ EDDY"
                        },
                        new
                        {
                            UserinfoId = 4,
                            Badgenumber = "4",
                            DepartmentId = 1,
                            Email = "dzapata@example.com",
                            Name = "ZAPATA DANIEL"
                        },
                        new
                        {
                            UserinfoId = 5,
                            Badgenumber = "55",
                            DepartmentId = 2,
                            Email = "jvillacis@example.com",
                            Name = "JOSE VILLACIS"
                        },
                        new
                        {
                            UserinfoId = 6,
                            Badgenumber = "66",
                            DepartmentId = 4,
                            Email = "pgaona@example.com",
                            Name = "PAULINA GAONA"
                        },
                        new
                        {
                            UserinfoId = 7,
                            Badgenumber = "77",
                            DepartmentId = 5,
                            Email = "jlfornell@example.com",
                            Name = "JL FORNELL"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Models.Entities.AuthAppUser.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.Entities.AuthAppUser.AppUser", null)
                        .WithMany("AppUserClaims")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Models.Entities.AuthAppUser.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.Entities.AuthAppUser.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.Entities.AuthAppUser.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Entities.AuthAppUser.AppUserRole", b =>
                {
                    b.HasOne("Models.Entities.AuthAppUser.Role", "Role")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AuthAppUser.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Models.Entities.Userinfo", b =>
                {
                    b.HasOne("Models.Entities.AuthAppUser.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("Models.Entities.Department", "Department")
                        .WithMany("Userinfos")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Models.Entities.AuthAppUser.AppUser", b =>
                {
                    b.Navigation("AppUserClaims");

                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("Models.Entities.AuthAppUser.Role", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("Models.Entities.Department", b =>
                {
                    b.Navigation("Userinfos");
                });
#pragma warning restore 612, 618
        }
    }
}