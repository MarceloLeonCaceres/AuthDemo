using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfData.Migrations
{
    /// <inheritdoc />
    public partial class StoreProcedureYCedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[SubDepartamentos]
            	                                    -- Add the parameters for the stored procedure here
            	                                    @id int 
                                                AS
                                                BEGIN
            	                                    -- SET NOCOUNT ON added to prevent extra result sets from
            	                                    -- interfering with SELECT statements.
            	                                    SET NOCOUNT ON;

                                                    -- Insert statements for procedure here
            	                                    WITH SubDepartamentos (Id, deptName, idPadre)
                                                AS    (
                                                SELECT Id, deptName, 0 FROM departments WHERE Id = 1
                                                UNION ALL                
                                                SELECT D.Id, D.deptName, D.idPadre FROM departments D inner join SubDepartamentos Sub on Sub.Id = D.idPadre 
                                                )
                                                Select Id, deptName, idPadre from SubDepartamentos
                                                END");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d52f835-94e1-409e-b180-4f370f40f98d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03adbccc-21e5-4fde-9d58-a319e104bc61", "AQAAAAIAAYagAAAAEF+vlLpHoCmnzLh2rmj3WBhAnbRTffFY+3ehVlp70FGYHxB0JKm2riFT6UmMuTYH9A==", "b8d8f216-7d7d-4a44-9f49-c1813c84bc99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25406532-ce96-4671-a41e-9a10c13e4d2e", "AQAAAAIAAYagAAAAEDA5qIQvCkwbMAlN4EFaJOJjP0icglCACQSCRMJNmazfehf6YYCeoFr0yWaSRCNd7g==", "f410bd23-9557-48ed-bb70-73d8dbd09c40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b7112b-1640-44e9-ba12-0a772f991285", "AQAAAAIAAYagAAAAEF1qTwtqDFX03DHsj5vPH0devGbhOC9lY8GEF8TuPIezrDVVI+NQYbvrTjoP4y1w0Q==", "2352b75d-8e69-454c-ae39-8bf8fe79df13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90d723c3-3472-4438-afb4-275e6c3871a4", "AQAAAAIAAYagAAAAEEZc8YzmKK1pSq5hjAFH03OYUNxLvKG/BjAh9CIjwJIBAyvvygLIJgwJ1qjSESDVcg==", "76dccb6a-f7b1-4c7e-8726-a44f449abeb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4c46da5-ea50-4654-9e83-170f075112d6", "AQAAAAIAAYagAAAAEFTy5FP/ZWOknnqwJJ3rmAc924OL9dN/TFSIbWH15rL2idXwsjtT6Cgq3qSr7UPatQ==", "095f4806-8d9e-4522-b3a6-fd0f22e8809c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88a8851f-16a2-4ac8-b00c-6a1d673d0ad3", "AQAAAAIAAYagAAAAEOMCy8/dk4EtCPHdqzXyyrr06Ow9hnNUusC3pUNib7Qk4V3SA7FHzVJRabh84fwHfg==", "66812d70-6573-4a38-91e8-b51001f4a966" });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 1,
                column: "SSN",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 2,
                column: "SSN",
                value: "1234567891");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 3,
                column: "SSN",
                value: "1234567892");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 4,
                column: "SSN",
                value: "1234567893");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 5,
                column: "SSN",
                value: "1234567894");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 6,
                column: "SSN",
                value: "1234567895");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 7,
                column: "SSN",
                value: "1234567896");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[SubDepartamentos]");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d52f835-94e1-409e-b180-4f370f40f98d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b13e807e-de68-413b-94e9-b64eb6e0247a", "AQAAAAIAAYagAAAAEFtoNvG5WVT9BctF8zxvQ9BYrHgb+BCCIYsTFm0m+jkvgOakbRjEi1vg3hDqiXQYCA==", "afd077a6-40e6-490b-bfcd-8e4ae92d5c20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9caa67fc-5ee2-4f5c-bb46-a3bf7d17419f", "AQAAAAIAAYagAAAAEIW30lUrF+uhjaaYmmJAQ947YKrTYfjB90GOaUpjdYOtoRP2qEDeTxM5PUI7tNz0+A==", "0a4c4273-91a9-429d-ba6d-8b7544d7b3df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dcfc20f-9fc9-4e1a-a0f6-ef112c083388", "AQAAAAIAAYagAAAAELEAzqAh3RZHLumfUgyu9aI21KLeguEsqGiqcoQCX4/Se7u72jJnRj3c9MTpC+PtfA==", "bfaa9915-6552-4a67-bbf6-3640153aa962" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd2daa07-a0d8-48f4-b8c6-5c72b75289a1", "AQAAAAIAAYagAAAAEMyDXCIpAb6UIQxu/vWgsr+oUR2OSHuAjPlMXwcJzDHDMl8Ol7RjLp13Obny6L6Xtg==", "631fcfe9-478c-4f36-89bb-6f6d47ef6160" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8f6cbfe-0c85-4878-9377-a460c322243f", "AQAAAAIAAYagAAAAED8jUBNDZ+61XzxwTiVM4VpsAtVnnWhNjKPdaDtYv8rb8PQyO6+B1NFcMNvUJRH4nA==", "69331ef8-548b-4b1b-9b84-111af0fd5c6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71bf9be6-602d-4c96-8bd9-6e170d0f946d", "AQAAAAIAAYagAAAAEJWGrNyAi1Yr5s5acGA4U+KmhvPucKOiGfiDRXWDLXNTQrFK61yfp6SbvxOI+lMwUg==", "66a9ba42-c4f3-4c41-9b86-5f3394235296" });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 1,
                column: "SSN",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 2,
                column: "SSN",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 3,
                column: "SSN",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 4,
                column: "SSN",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 5,
                column: "SSN",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 6,
                column: "SSN",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "UserinfoId",
                keyValue: 7,
                column: "SSN",
                value: null);
        }
    }
}
