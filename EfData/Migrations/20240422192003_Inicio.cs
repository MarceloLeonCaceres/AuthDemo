using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfData.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserinfoId = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdPadre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usersinfo",
                columns: table => new
                {
                    UserinfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Badgenumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HiredDay = table.Column<DateOnly>(type: "date", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usersinfo", x => x.UserinfoId);
                    table.ForeignKey(
                        name: "FK_Usersinfo_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usersinfo_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "017ba3c7-6860-48fe-a066-fe005ae54521", null, "visorReportes", "VISORREPORTES" },
                    { "1b7d2e86-b210-4846-9530-16962a69af6d", null, "supervisorMR", "SUPERVISORMR" },
                    { "4899d69d-bfef-4a1b-972b-c66cc56b7a89", null, "planificador", "PLANIFICADOR" },
                    { "86e60536-b2ab-4ac5-85b8-e2afd8fe7058", null, "supervisorPermisos", "SUPERVISORPERMISOS" },
                    { "ab4cd34b-8232-4244-b459-cb150202c040", null, "admin", "ADMIN" },
                    { "bf52d74f-adb0-4a8a-b8fa-bb0141ab9a29", null, "user", "USER" },
                    { "c8c2a86c-7c38-45e5-95ac-b067a19aea4f", null, "th", "TH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserinfoId" },
                values: new object[,]
                {
                    { "0d52f835-94e1-409e-b180-4f370f40f98d", 0, "b13e807e-de68-413b-94e9-b64eb6e0247a", "aprueba1@example.com", false, false, null, "APRUEBA1@EXAMPLE.COM", "APRUEBA1", "AQAAAAIAAYagAAAAEFtoNvG5WVT9BctF8zxvQ9BYrHgb+BCCIYsTFm0m+jkvgOakbRjEi1vg3hDqiXQYCA==", null, false, null, null, "afd077a6-40e6-490b-bfcd-8e4ae92d5c20", false, "Aprueba1", null },
                    { "22472f44-f29e-4317-ac81-966e5c4a6035", 0, "9caa67fc-5ee2-4f5c-bb46-a3bf7d17419f", "thumano1@example.com", false, false, null, "THUMANO1@EXAMPLE.COM", "THUMANO1", "AQAAAAIAAYagAAAAEIW30lUrF+uhjaaYmmJAQ947YKrTYfjB90GOaUpjdYOtoRP2qEDeTxM5PUI7tNz0+A==", null, false, null, null, "0a4c4273-91a9-429d-ba6d-8b7544d7b3df", false, "THumano1", null },
                    { "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7", 0, "6dcfc20f-9fc9-4e1a-a0f6-ef112c083388", "planeador1@example.com", false, false, null, "PLANEADOR1@EXAMPLE.COM", "PLANEADOR1", "AQAAAAIAAYagAAAAELEAzqAh3RZHLumfUgyu9aI21KLeguEsqGiqcoQCX4/Se7u72jJnRj3c9MTpC+PtfA==", null, false, null, null, "bfaa9915-6552-4a67-bbf6-3640153aa962", false, "Planeador1", null },
                    { "5eb32700-9d1f-48fb-9116-cf9647747ff7", 0, "bd2daa07-a0d8-48f4-b8c6-5c72b75289a1", "reporte1@example.com", false, false, null, "REPORTE1@EXAMPLE.COM", "REPORTE1", "AQAAAAIAAYagAAAAEMyDXCIpAb6UIQxu/vWgsr+oUR2OSHuAjPlMXwcJzDHDMl8Ol7RjLp13Obny6L6Xtg==", null, false, null, null, "631fcfe9-478c-4f36-89bb-6f6d47ef6160", false, "Reporte1", null },
                    { "869f332e-a84d-4803-af9b-91b4c679ecb9", 0, "f8f6cbfe-0c85-4878-9377-a460c322243f", "Admin123@example.com", false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN123", "AQAAAAIAAYagAAAAED8jUBNDZ+61XzxwTiVM4VpsAtVnnWhNjKPdaDtYv8rb8PQyO6+B1NFcMNvUJRH4nA==", null, false, null, null, "69331ef8-548b-4b1b-9b84-111af0fd5c6b", false, "Admin123", null },
                    { "9bc4b3f3-e392-41da-aa6a-8c65f8556192", 0, "71bf9be6-602d-4c96-8bd9-6e170d0f946d", "aprueba3@example.com", false, false, null, "APRUEBA3@EXAMPLE.COM", "APRUEBA3", "AQAAAAIAAYagAAAAEJWGrNyAi1Yr5s5acGA4U+KmhvPucKOiGfiDRXWDLXNTQrFK61yfp6SbvxOI+lMwUg==", null, false, null, null, "66a9ba42-c4f3-4c41-9b86-5f3394235296", false, "Aprueba3", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName", "IdPadre" },
                values: new object[,]
                {
                    { 1, "Empresa", 0 },
                    { 2, "Financiero", 1 },
                    { 3, "Ventas", 1 },
                    { 4, "Talento Humano", 1 },
                    { 5, "Marketing", 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "86e60536-b2ab-4ac5-85b8-e2afd8fe7058", "0d52f835-94e1-409e-b180-4f370f40f98d" },
                    { "c8c2a86c-7c38-45e5-95ac-b067a19aea4f", "22472f44-f29e-4317-ac81-966e5c4a6035" },
                    { "4899d69d-bfef-4a1b-972b-c66cc56b7a89", "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7" },
                    { "017ba3c7-6860-48fe-a066-fe005ae54521", "5eb32700-9d1f-48fb-9116-cf9647747ff7" },
                    { "ab4cd34b-8232-4244-b459-cb150202c040", "869f332e-a84d-4803-af9b-91b4c679ecb9" },
                    { "1b7d2e86-b210-4846-9530-16962a69af6d", "9bc4b3f3-e392-41da-aa6a-8c65f8556192" }
                });

            migrationBuilder.InsertData(
                table: "Usersinfo",
                columns: new[] { "UserinfoId", "AppUserId", "Badgenumber", "DepartmentId", "Email", "HiredDay", "Name", "SSN" },
                values: new object[,]
                {
                    { 1, null, "1", 1, "gacero@example.com", null, "ACERO GLORIA", null },
                    { 2, null, "2", 1, "rbarcia@example.com", null, "BARCIA RUTH", null },
                    { 3, null, "3", 1, "elopez@example.com", null, "LOPEZ EDDY", null },
                    { 4, null, "4", 1, "dzapata@example.com", null, "ZAPATA DANIEL", null },
                    { 5, null, "55", 2, "jvillacis@example.com", null, "JOSE VILLACIS", null },
                    { 6, null, "66", 4, "pgaona@example.com", null, "PAULINA GAONA", null },
                    { 7, null, "77", 5, "jlfornell@example.com", null, "JL FORNELL", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_ApplicationUserId",
                table: "AspNetUserClaims",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usersinfo_AppUserId",
                table: "Usersinfo",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usersinfo_Badgenumber",
                table: "Usersinfo",
                column: "Badgenumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usersinfo_DepartmentId",
                table: "Usersinfo",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Usersinfo_Name",
                table: "Usersinfo",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Usersinfo_SSN",
                table: "Usersinfo",
                column: "SSN",
                unique: true,
                filter: "[SSN] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Usersinfo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
