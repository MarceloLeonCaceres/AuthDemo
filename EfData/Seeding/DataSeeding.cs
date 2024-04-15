using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.AuthAppUser;
using Models.Entities;
using Models.Entities.AuthAppUser;
using Models.Entities.Enums;

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
            modelBuilder.Entity<Department>().HasData(deptoRaiz, finanzas, ventas, th);

            Userinfo gloria = new Userinfo { UserinfoId = 1, Badgenumber = "1", Name = "ACERO GLORIA", DepartmentId = deptoRaiz.Id, Email = "gacero@example.com" };
            Userinfo ruth = new Userinfo { UserinfoId = 2, Badgenumber = "2", Name = "BARCIA RUTH", DepartmentId = deptoRaiz.Id, Email = "rbarcia@example.com" };
            Userinfo eddy = new Userinfo { UserinfoId = 3, Badgenumber = "3", Name = "LOPEZ EDDY", DepartmentId = deptoRaiz.Id, Email = "elopez@example.com" };
            Userinfo daniel = new Userinfo { UserinfoId = 4, Badgenumber = "4", Name = "ZAPATA DANIEL", DepartmentId = deptoRaiz.Id, Email = "dzapata@example.com" };
            Userinfo jose = new Userinfo { UserinfoId = 5, Badgenumber = "55", Name = "JOSE VILLACIS", DepartmentId = finanzas.Id, Email = "jvillacis@example.com" };
            Userinfo paulina = new Userinfo { UserinfoId = 6, Badgenumber = "66", Name = "PAULINA GAONA", DepartmentId = th.Id, Email = "pgaona@example.com" };
            modelBuilder.Entity<Userinfo>().HasData(gloria, ruth, eddy, daniel, jose, paulina);


            string password = "Passw0rd";
            var appPassword = new PasswordHasher<AppUser>();
            
            AppUser adminAppUser = new AppUser
            {
                UserName = "Admin123",
                Id = "869f332e-a84d-4803-af9b-91b4c679ecb9",
                NormalizedUserName = "ADMIN123",
                Email = "Admin123@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM"
            };
            AppUser AppUser = new AppUser
            {
                UserName = "",
                Id = "",
                NormalizedUserName = "",
                Email = "@example.com",
                NormalizedEmail = "@EXAMPLE.COM"
            };
            AppUser Aprueba1AppUser = new AppUser
            {
                UserName = "Aprueba1",
                Id = "0d52f835-94e1-409e-b180-4f370f40f98d",
                NormalizedUserName = "APRUEBA1",
                Email = "aprueba1@example.com",
                NormalizedEmail = "APRUEBA1@EXAMPLE.COM"
            };
            AppUser Aprueba3AppUser = new AppUser
            {
                UserName = "Aprueba3",
                Id = "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                NormalizedUserName = "APRUEBA3",
                Email = "aprueba3@example.com",
                NormalizedEmail = "APRUEBA3@EXAMPLE.COM"
            };
            AppUser Planeador1AppUser = new AppUser
            {
                UserName = "Planeador1",
                Id = "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                NormalizedUserName = "PLANEADOR1",
                Email = "planeador1@example.com",
                NormalizedEmail = "PLANEADOR1@EXAMPLE.COM"
            };
            AppUser THumano1AppUser = new AppUser
            {
                UserName = "THumano1",
                Id = "22472f44-f29e-4317-ac81-966e5c4a6035",
                NormalizedUserName = "THUMANO1",
                Email = "thumano1@example.com",
                NormalizedEmail = "THUMANO1@EXAMPLE.COM"
            };
            AppUser Reporte1AppUser = new AppUser
            {
                UserName = "Reporte1",
                Id = "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                NormalizedUserName = "REPORTE1",
                Email = "reporte1@example.com",
                NormalizedEmail = "REPORTE1@EXAMPLE.COM"
            };

            var hashed = appPassword.HashPassword(adminAppUser, password);
            adminAppUser.PasswordHash = hashed;
            modelBuilder.Entity<AppUser>().HasData(adminAppUser, Aprueba1AppUser, Aprueba3AppUser, Planeador1AppUser, THumano1AppUser, Reporte1AppUser);

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

        }                    

    }
}
