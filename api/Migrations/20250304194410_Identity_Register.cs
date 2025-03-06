using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Identity_Register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b32c0c8-9761-46bd-beca-35eb76bf33b2", null, "Admin", "ADMIN" },
                    { "c6df0ad1-677d-4ddb-b309-a209286adb3b", null, "User", "User" },
                    { "edbfa5a2-2775-43ef-9aee-eafd48b6f626", null, "Moderator", "MODERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b32c0c8-9761-46bd-beca-35eb76bf33b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6df0ad1-677d-4ddb-b309-a209286adb3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbfa5a2-2775-43ef-9aee-eafd48b6f626");
        }
    }
}
