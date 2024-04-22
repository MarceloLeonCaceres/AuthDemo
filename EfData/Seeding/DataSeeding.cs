using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.DTOs.AuthAppUser;
using Models.Entities;
using Models.Entities.AuthAppUser;
using Models.Entities.Enums;
using System.Security.Claims;

namespace EfData.Seeding
{
    public static class DataSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            List<Role> roles = new List<Role>
            {
                new Role ( "ab4cd34b-8232-4244-b459-cb150202c040", "admin", "ADMIN" ),
                new Role ( "4899d69d-bfef-4a1b-972b-c66cc56b7a89", "planificador", "PLANIFICADOR"),
                new Role ( "86e60536-b2ab-4ac5-85b8-e2afd8fe7058", "supervisorPermisos", "SUPERVISORPERMISOS"),
                new Role ( "1b7d2e86-b210-4846-9530-16962a69af6d", "supervisorMR", "SUPERVISORMR"),
                new Role ( "c8c2a86c-7c38-45e5-95ac-b067a19aea4f", "th", "TH"),
                new Role ( "bf52d74f-adb0-4a8a-b8fa-bb0141ab9a29", "user", "USER"),
                new Role ( "017ba3c7-6860-48fe-a066-fe005ae54521", "visorReportes", "VISORREPORTES")
            };
            modelBuilder.Entity<Role>().HasData(roles);

            Department deptoRaiz = new Department { Id = 1, DeptName = "Empresa", IdPadre = 0 };
            Department finanzas = new Department { Id = 2, DeptName = "Financiero", IdPadre = 1 };
            Department ventas = new Department { Id = 3, DeptName = "Ventas", IdPadre = 1 };
            Department th = new Department { Id = 4, DeptName = "Talento Humano", IdPadre = 1 };
            Department marketing = new Department { Id = 5, DeptName = "Marketing", IdPadre = 3 };
            modelBuilder.Entity<Department>().HasData(deptoRaiz, finanzas, ventas, th, marketing);

            Userinfo gloria = new Userinfo { UserinfoId = 1, Badgenumber = "1", Name = "ACERO GLORIA", SSN = "1234567890", DepartmentId = deptoRaiz.Id, Email = "gacero@example.com" };
            Userinfo ruth = new Userinfo { UserinfoId = 2, Badgenumber = "2", Name = "BARCIA RUTH", SSN = "1234567891", DepartmentId = deptoRaiz.Id, Email = "rbarcia@example.com" };
            Userinfo eddy = new Userinfo { UserinfoId = 3, Badgenumber = "3", Name = "LOPEZ EDDY", SSN = "1234567892", DepartmentId = deptoRaiz.Id, Email = "elopez@example.com" };
            Userinfo daniel = new Userinfo { UserinfoId = 4, Badgenumber = "4", Name = "ZAPATA DANIEL", SSN = "1234567893", DepartmentId = deptoRaiz.Id, Email = "dzapata@example.com" };
            Userinfo jose = new Userinfo { UserinfoId = 5, Badgenumber = "55", Name = "JOSE VILLACIS", SSN = "1234567894", DepartmentId = finanzas.Id, Email = "jvillacis@example.com" };
            Userinfo paulina = new Userinfo { UserinfoId = 6, Badgenumber = "66", Name = "PAULINA GAONA", SSN = "1234567895", DepartmentId = th.Id, Email = "pgaona@example.com" };
            Userinfo fornell = new Userinfo { UserinfoId = 7, Badgenumber = "77", Name = "JL FORNELL", SSN = "1234567896", DepartmentId = marketing.Id, Email = "jlfornell@example.com" };
            modelBuilder.Entity<Userinfo>().HasData(gloria, ruth, eddy, daniel, jose, paulina, fornell);


            string password = "Passw0rd";
            var appPassword = new PasswordHasher<ApplicationUser>();
            
            ApplicationUser adminAppUser = new ApplicationUser
            {
                UserName = "Admin123",
                Id = "869f332e-a84d-4803-af9b-91b4c679ecb9",
                NormalizedUserName = "ADMIN123",
                Email = "Admin123@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM"
            };
            ApplicationUser AppUser = new ApplicationUser
            {
                UserName = "",
                Id = "",
                NormalizedUserName = "",
                Email = "@example.com",
                NormalizedEmail = "@EXAMPLE.COM"
            };
            ApplicationUser Aprueba1AppUser = new ApplicationUser
            {
                UserName = "Aprueba1",
                Id = "0d52f835-94e1-409e-b180-4f370f40f98d",
                NormalizedUserName = "APRUEBA1",
                Email = "aprueba1@example.com",
                NormalizedEmail = "APRUEBA1@EXAMPLE.COM"
            };
            ApplicationUser Aprueba3AppUser = new ApplicationUser
            {
                UserName = "Aprueba3",
                Id = "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                NormalizedUserName = "APRUEBA3",
                Email = "aprueba3@example.com",
                NormalizedEmail = "APRUEBA3@EXAMPLE.COM"
            };
            ApplicationUser Planeador1AppUser = new ApplicationUser
            {
                UserName = "Planeador1",
                Id = "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                NormalizedUserName = "PLANEADOR1",
                Email = "planeador1@example.com",
                NormalizedEmail = "PLANEADOR1@EXAMPLE.COM"
            };
            ApplicationUser THumano1AppUser = new ApplicationUser
            {
                UserName = "THumano1",
                Id = "22472f44-f29e-4317-ac81-966e5c4a6035",
                NormalizedUserName = "THUMANO1",
                Email = "thumano1@example.com",
                NormalizedEmail = "THUMANO1@EXAMPLE.COM"
            };
            ApplicationUser Reporte1AppUser = new ApplicationUser
            {
                UserName = "Reporte1",
                Id = "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                NormalizedUserName = "REPORTE1",
                Email = "reporte1@example.com",
                NormalizedEmail = "REPORTE1@EXAMPLE.COM"
            };

            var hashed = appPassword.HashPassword(adminAppUser, password);
            adminAppUser.PasswordHash = hashed;
            hashed = appPassword.HashPassword(Aprueba1AppUser, password);
            Aprueba1AppUser.PasswordHash = hashed; 
            hashed = appPassword.HashPassword(Aprueba3AppUser, password);
            Aprueba3AppUser.PasswordHash = hashed; 
            hashed = appPassword.HashPassword(Planeador1AppUser, password);
            Planeador1AppUser.PasswordHash = hashed; 
            hashed = appPassword.HashPassword(THumano1AppUser, password);
            THumano1AppUser.PasswordHash = hashed; 
            hashed = appPassword.HashPassword(Reporte1AppUser, password);
            Reporte1AppUser.PasswordHash = hashed; 
            
            modelBuilder.Entity<ApplicationUser>().HasData(adminAppUser, Aprueba1AppUser, Aprueba3AppUser, Planeador1AppUser, THumano1AppUser, Reporte1AppUser);

            AppUserRole adminUser_admin = new AppUserRole
            {
                UserId = "869f332e-a84d-4803-af9b-91b4c679ecb9",
                RoleId = "ab4cd34b-8232-4244-b459-cb150202c040"
            };
            AppUserRole aprobador1 = new AppUserRole
            {
                UserId = "0d52f835-94e1-409e-b180-4f370f40f98d",
                RoleId = "86e60536-b2ab-4ac5-85b8-e2afd8fe7058"
            };
            AppUserRole aprobador3 = new AppUserRole
            {
                UserId = "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                RoleId = "1b7d2e86-b210-4846-9530-16962a69af6d"
            };
            AppUserRole planeador = new AppUserRole
            {
                UserId = "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                RoleId = "4899d69d-bfef-4a1b-972b-c66cc56b7a89"
            };
            AppUserRole thumano = new AppUserRole
            {
                UserId = "22472f44-f29e-4317-ac81-966e5c4a6035",
                RoleId = "c8c2a86c-7c38-45e5-95ac-b067a19aea4f"
            };
            AppUserRole reporteador = new AppUserRole
            {
                UserId = "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                RoleId = "017ba3c7-6860-48fe-a066-fe005ae54521"
            };

            modelBuilder.Entity<AppUserRole>().HasData(adminUser_admin, aprobador1, aprobador3, planeador, thumano, reporteador);

            //Claim claimSA = new Claim("OtAdmin", "3");    // Super Administrador
            //Claim claimADepto = new Claim("OtAdmin", "2");    // Administrador de Departamento
            //Claim claimALocal = new Claim("OtAdmin", "1");    // Administrador Local
            //Claim claimDeptoRaiz = new Claim("DeptId", "1");      //Department 1 = Empresa
            //Claim claimDeptoFinanciero = new Claim("DeptId", "2");      //Department 2 = Finanzas
            //Claim claimDeptoVentas = new Claim("DeptId", "3");      //Department 3 = Ventas
            //Claim claimDeptoTH = new Claim("DeptId", "4");      //Department 4 = Talento Humano

            //// AppUserClaim claimsAdmin = new AppUserClaim(adminAppUser, claimSA);
            //AppUserClaim appUserClaim = new AppUserClaim
            //{
            //    Id = -1,
            //    UserId = adminAppUser.Id,
            //    ClaimType = "OtAdmin",
            //    ClaimValue = "1",
            //    ApplicationUser = adminAppUser
            //};

            //modelBuilder.Entity<AppUserClaim>().HasData(
            //    new AppUserClaim(1, adminAppUser.Id, "OtAdmin", "3"),
            //    new AppUserClaim(2, adminAppUser.Id, "DeptId", "1"),
            //    new AppUserClaim(3, Planeador1AppUser.Id, "DeptId", "3"),
            //    new AppUserClaim(4, Planeador1AppUser.Id, "OtAdmin", "2"),
            //    new AppUserClaim(5, THumano1AppUser.Id, "OtAdmin", "3"),
            //    new AppUserClaim(6, THumano1AppUser.Id, "DeptId", "4"),
            //    new AppUserClaim(7, Reporte1AppUser.Id, "DeptId", "2"),
            //    new AppUserClaim(7, Reporte1AppUser.Id, "OtAdmin", "1"),
            //    appUserClaim
            //);
        }                    

    }
}

// Up

//migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[SubDepartamentos]
//	                                    -- Add the parameters for the stored procedure here
//	                                    @id int 
//                                    AS
//                                    BEGIN
//	                                    -- SET NOCOUNT ON added to prevent extra result sets from
//	                                    -- interfering with SELECT statements.
//	                                    SET NOCOUNT ON;

//                                        -- Insert statements for procedure here
//	                                    WITH SubDepartamentos (Id, deptName, idPadre)
//                                    AS    (
//                                    SELECT Id, deptName, 0 FROM departments WHERE Id = 1
//                                    UNION ALL                
//                                    SELECT D.Id, D.deptName, D.idPadre FROM departments D inner join SubDepartamentos Sub on Sub.Id = D.idPadre 
//                                    )
//                                    Select Id, deptName, idPadre from SubDepartamentos
//                                    END");


// Down


// migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[SubDepartamentos]");
