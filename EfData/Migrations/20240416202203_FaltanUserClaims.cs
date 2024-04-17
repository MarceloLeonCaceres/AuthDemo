using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfData.Migrations
{
    /// <inheritdoc />
    public partial class FaltanUserClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d52f835-94e1-409e-b180-4f370f40f98d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e619a35-f1cb-4b29-9523-3e1af13dd0fc", "AQAAAAIAAYagAAAAEAjQrUBI8mDFecht8mFjsT8olwEILHamYCk2nTttQpL6J5d5j1vWKM6tYocvDbWWZA==", "c6c03b15-d2f4-4a15-a7a8-525d72beefd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22472f44-f29e-4317-ac81-966e5c4a6035",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f336a6-c854-4402-bb01-e860a530c184", "AQAAAAIAAYagAAAAECPUWlqh7ezJ7GDQcwoUqUNFR+i0c6UUwLeuFCJc6x6rZJVV0y5OSRf4Xv7zgQ5zAw==", "716b08f8-09e9-4872-b9bb-3c562b50fb15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f81f8ad-5bcc-447a-bc33-7b30b87cefd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "847e466a-83ce-4df5-82d8-6e9d5930834f", "AQAAAAIAAYagAAAAEJekNZqT8VqRxG4550cK2re2b8GzRTvYKuwK3n315x5SanKtoVqgZXNplMYwQGTxog==", "cafbd919-c269-4011-938f-c1ed26760639" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb32700-9d1f-48fb-9116-cf9647747ff7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09cade9f-b56c-4f9d-85a9-9c94a27ba8db", "AQAAAAIAAYagAAAAEIHQg7aCkQVPZcKH56N93Ek5j2j7pLQUmgk31fK+ppejCOIQ6AZJeK2WvauA3IT0fA==", "ab938195-d43d-4cd4-b73e-91541126437e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "869f332e-a84d-4803-af9b-91b4c679ecb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "646a3550-4b2c-44f2-8a33-a9e43ec65848", "AQAAAAIAAYagAAAAEPVJ9Wgm1y6vmSp+6y7x7IP/Jgk5kypihcesScsoLNAV8erWr0blZsH9mKzJaHTsbQ==", "69053cd1-f6d9-47d2-a25f-09f127798e46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bc4b3f3-e392-41da-aa6a-8c65f8556192",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60402cde-6b83-49cf-a405-7eeee732f386", "AQAAAAIAAYagAAAAEJZN/Xr49pZw6YiRqxLBJiaUlh6EGvZ1RxfxEmYXm2K89Ed+VUafYnsrdLs8iMxe9A==", "0a2a8bfb-7158-4c60-ba66-e7d1e6905439" });
        }
    }
}
