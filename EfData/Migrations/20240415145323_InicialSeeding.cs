using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfData.Migrations
{
    /// <inheritdoc />
    public partial class InicialSeeding : Migration
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
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d52f835-94e1-409e-b180-4f370f40f98d", 0, "a2a87aa3-271f-45c3-bdb9-40f155ad7dc8", "aprueba1@example.com", false, false, null, "APRUEBA1@EXAMPLE.COM", "APRUEBA1", null, null, false, null, null, "8193067e-856f-41d0-b7a0-e604e6a45305", false, "Aprueba1" },
                    { "22472f44-f29e-4317-ac81-966e5c4a6035", 0, "25b17609-04e4-4953-9c79-24d807a7be74", "thumano1@example.com", false, false, null, "THUMANO1@EXAMPLE.COM", "THUMANO1", null, null, false, null, null, "c8978892-0e67-42ca-8b3f-aeea5e5e64d6", false, "THumano1" },
                    { "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7", 0, "e3db25e0-560c-4abd-90bf-aaa76ce50481", "planeador1@example.com", false, false, null, "PLANEADOR1@EXAMPLE.COM", "PLANEADOR1", null, null, false, null, null, "194681a1-2fe4-4a30-b130-33d8c60915bd", false, "Planeador1" },
                    { "5eb32700-9d1f-48fb-9116-cf9647747ff7", 0, "308f9ff4-983b-4b64-944c-dde9755adea5", "reporte1@example.com", false, false, null, "REPORTE1@EXAMPLE.COM", "REPORTE1", null, null, false, null, null, "c8cb7f4f-a32a-4c94-90ff-0f2d5d9e97f0", false, "Reporte1" },
                    { "869f332e-a84d-4803-af9b-91b4c679ecb9", 0, "b1bc6c74-2005-4be8-bb24-aac5cc51a2bc", "Admin123@example.com", false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN123", "AQAAAAIAAYagAAAAEMf77A4JIm4HFLQOIyAbG4aNJIRDGAS1gALachUbpdQ6DVsYlbf2QyUEUKw5WPdN/Q==", null, false, null, null, "3052bcbc-df31-47ad-a8f3-b3f7c6056fca", false, "Admin123" },
                    { "9bc4b3f3-e392-41da-aa6a-8c65f8556192", 0, "42d1fdd8-74d8-478b-be2b-6ddb5fa54be3", "aprueba3@example.com", false, false, null, "APRUEBA3@EXAMPLE.COM", "APRUEBA3", null, null, false, null, null, "34952211-75d3-4b06-81e7-8ff591f07970", false, "Aprueba3" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName", "IdPadre" },
                values: new object[,]
                {
                    { 1, "Empresa", 0 },
                    { 2, "Financiero", 1 },
                    { 3, "Ventas", 1 },
                    { 4, "Talento Humano", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab4cd34b-8232-4244-b459-cb150202c040", "869f332e-a84d-4803-af9b-91b4c679ecb9" });

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
                    { 6, null, "66", 4, "pgaona@example.com", null, "PAULINA GAONA", null }
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
                name: "IX_AspNetUserClaims_AppUserId",
                table: "AspNetUserClaims",
                column: "AppUserId");

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
                column: "AppUserId");

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
