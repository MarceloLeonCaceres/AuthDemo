using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfData.Migrations
{
    /// <inheritdoc />
    public partial class StoreProcedureSubDeptos : Migration
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
                values: new object[] { "7052f5a1-6b6c-4158-bb35-308abc4fe714", "AQAAAAIAAYagAAAAEMrh4S9M/VqxsLcdW91FOYDmaOH7MJTLyFrVmf8ep8bNzhtRPVNcHjgPQEpH0y5kCw==", "b48cb3b6-cb8b-4e6b-abb3-e4ecd85fec2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e4a1790-423a-4ade-8ddc-79d2bf5f3878", "AQAAAAIAAYagAAAAEAU6LvxbpTQn8MrnMGHT3kVxDMpMvDDgjmnB6uQ5W2y9SEBBIjSh5bGFsqwFWcVukA==", "e2bee33a-cbcb-4150-93ae-731a5cde0396" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83dac0f3-e054-4cbb-add0-8eb07e1010ac", "AQAAAAIAAYagAAAAEP8wpnddFNcaJEXoNLgtv7V1hZWr412wF3HsWnBcKqXPkYh6C8QTOw6NEvGf0cZvfA==", "6aa43204-20cd-413a-bb72-259e98388e07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92eea465-2ee5-4118-bb6a-916a5edf5b90", "AQAAAAIAAYagAAAAEH4nZjzlOCShWaoc0WfrBxtnk6Zkv4qQ/yDTgmqSai8RSm6vO79fK4CG8dydEbq4EQ==", "4e984034-7b01-4b44-8bd2-0c967f5013eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "810a668e-ba83-4cda-8ae5-fd7e543ca22b", "AQAAAAIAAYagAAAAENX4If80rSGMYZUI5gOcOTr2dnG5EKhkiUlpGHwngpMEthC4RoVwv+yidMs33oU9uw==", "6ff662ac-2f01-43d5-bdde-c9ad2ba19827" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "599e2df0-f5aa-445c-964c-32abd2e7645c", "AQAAAAIAAYagAAAAEO4y2ppfT55dOLxESBBV6PZYojxsA5n/z7QSgUU83DvdMzBh9wCwSBt5RXeihP38uQ==", "9b1c7d0a-4db5-493b-8d9e-aa0c95f5f6e6" });
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
                values: new object[] { "9a8c64f6-9b7f-4426-8f1c-6c7693c69ffa", "AQAAAAIAAYagAAAAEDZPZ11D+ChFdtK+Lr/5ajMSYYGyMrjSRT7nUcbQRhTWF2rY16eByA3eIP0ssMc3qQ==", "25c4083b-b915-48ba-bcec-1d2427f72283" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f3c31bc-36a3-4f5f-ab59-6bb9e91f4a78", "AQAAAAIAAYagAAAAEAVQg5zY+O1NYs7O8AZHFE6cR9Hup8ze1VHyXQ94STv/2AoHd89nNy7brXh4bZ44nQ==", "77d5bcc3-1b0a-4e47-bb74-6789e29b4fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e9eba7b-285a-4d59-a087-4e7ab766fada", "AQAAAAIAAYagAAAAEJMGQm+aijVHBXTkYJPBBmpt+w+aQyIgVNx9hg4CDYKR5ayoQi6GFwrVSMSe3P37ug==", "2b0163ac-8668-43e9-a4bd-e6a640e08fec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c0b8a29-6c2f-4796-b4e2-666de0426da0", "AQAAAAIAAYagAAAAENd2RmdHjr5RR0n11sGMp/zPnuZqqM48HBs3Lqfkt2arnbP5U+/WTb1QH4vfVi1lCQ==", "aaea5b61-213b-47de-8158-02c3d47a70ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4096abc-3594-4923-83a9-ee4fe151397d", "AQAAAAIAAYagAAAAENFZBZnBSiz3bHBLNZ0gLo7Q1r/+K203lbz6mfmVDMAcQDFF1LT3zjYDQzPyh9Cj+g==", "fc099548-de00-486e-bbc5-54cf96a50d5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d907f13c-61f8-4fdc-b57a-e780cee27f82", "AQAAAAIAAYagAAAAEC2yQg0DWqcPjE6m23pbukTE57rt+SUB6VNE5RQfR75u+Rm8vzvKnrJlcy7/Oo5zvQ==", "8f0a8ebe-b397-402b-97db-170da4067074" });
        }
    }
}
