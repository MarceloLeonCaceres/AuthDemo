using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfData.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "86e60536-b2ab-4ac5-85b8-e2afd8fe7058", "0d52f835-94e1-409e-b180-4f370f40f98d" },
                    { "c8c2a86c-7c38-45e5-95ac-b067a19aea4f", "22472f44-f29e-4317-ac81-966e5c4a6035" },
                    { "4899d69d-bfef-4a1b-972b-c66cc56b7a89", "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7" },
                    { "017ba3c7-6860-48fe-a066-fe005ae54521", "5eb32700-9d1f-48fb-9116-cf9647747ff7" },
                    { "1b7d2e86-b210-4846-9530-16962a69af6d", "9bc4b3f3-e392-41da-aa6a-8c65f8556192" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d52f835-94e1-409e-b180-4f370f40f98d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9695edba-cc0c-4727-956d-54ac476e3f45", "74a0db77-a5df-4552-b07c-dceba3b4d443" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "abeeda83-e2b3-47b4-ad68-d9e833f533c8", "57f5c02f-2b06-4e95-bdbf-e451b879c692" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76e02681-c391-4d2d-a0aa-29f9bc9c3b40", "5d416c9f-76ea-4ad9-9e6c-fd8cb351757a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ae8da8b-9776-425d-8746-09249362e4a6", "56aa9c7d-3988-4104-978c-cd9be8b1451e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3c82622-e72e-4e78-a6bc-6e90111e1392", "AQAAAAIAAYagAAAAEHCR2PZTLfYMpOvd6abCqctqajcwpbnHDdxDOkl+EkMoM8IS5grbcIKulAH2/KJV7w==", "6f42c549-c76a-4f52-abf6-63ab9eb3bb9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7a00c19f-0b75-43db-a418-1b87df6e7463", "5b285f68-2a12-4f24-a323-820536a48836" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "86e60536-b2ab-4ac5-85b8-e2afd8fe7058", "0d52f835-94e1-409e-b180-4f370f40f98d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8c2a86c-7c38-45e5-95ac-b067a19aea4f", "22472f44-f29e-4317-ac81-966e5c4a6035" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4899d69d-bfef-4a1b-972b-c66cc56b7a89", "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "017ba3c7-6860-48fe-a066-fe005ae54521", "5eb32700-9d1f-48fb-9116-cf9647747ff7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1b7d2e86-b210-4846-9530-16962a69af6d", "9bc4b3f3-e392-41da-aa6a-8c65f8556192" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d52f835-94e1-409e-b180-4f370f40f98d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2a87aa3-271f-45c3-bdb9-40f155ad7dc8", "8193067e-856f-41d0-b7a0-e604e6a45305" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "25b17609-04e4-4953-9c79-24d807a7be74", "c8978892-0e67-42ca-8b3f-aeea5e5e64d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e3db25e0-560c-4abd-90bf-aaa76ce50481", "194681a1-2fe4-4a30-b130-33d8c60915bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "308f9ff4-983b-4b64-944c-dde9755adea5", "c8cb7f4f-a32a-4c94-90ff-0f2d5d9e97f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1bc6c74-2005-4be8-bb24-aac5cc51a2bc", "AQAAAAIAAYagAAAAEMf77A4JIm4HFLQOIyAbG4aNJIRDGAS1gALachUbpdQ6DVsYlbf2QyUEUKw5WPdN/Q==", "3052bcbc-df31-47ad-a8f3-b3f7c6056fca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42d1fdd8-74d8-478b-be2b-6ddb5fa54be3", "34952211-75d3-4b06-81e7-8ff591f07970" });
        }
    }
}
