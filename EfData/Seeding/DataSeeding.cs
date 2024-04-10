using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                new Role ( "admin", "ADMIN"),
                new Role ( "planificador", "PLANIFICADOR"),
                new Role ( "supervisorPermisos", "SUPERVISORPERMISOS"),
                new Role ( "supervisorMR", "SUPERVISORMR"),
                new Role ( "th", "TH"),
                new Role ( "user", "USER"),
                new Role ( "visorReportes", "VISORREPORTES")
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

        }
    }
}
