using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartProducts_Carts_CartId",
                table: "cartProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3915e851-aaf7-435c-a483-a8208d7d5201");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bf532f2-1686-48e2-bae6-c262bfa53c88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1841e79-98a0-4a79-afc5-ac17a7c8ac96");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "cartProducts",
                newName: "UserCartId");

            migrationBuilder.RenameIndex(
                name: "IX_cartProducts_CartId",
                table: "cartProducts",
                newName: "IX_cartProducts_UserCartId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9c99b1c-9780-48cf-808f-9f351d0aed23", null, "Moderator", "MODERATOR" },
                    { "c6136cc2-d948-4c28-8800-89513c3790fe", null, "User", "User" },
                    { "dbfc942f-b80b-426e-8b4e-5b4cc9381892", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_cartProducts_Carts_UserCartId",
                table: "cartProducts",
                column: "UserCartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartProducts_Carts_UserCartId",
                table: "cartProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c99b1c-9780-48cf-808f-9f351d0aed23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6136cc2-d948-4c28-8800-89513c3790fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbfc942f-b80b-426e-8b4e-5b4cc9381892");

            migrationBuilder.RenameColumn(
                name: "UserCartId",
                table: "cartProducts",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_cartProducts_UserCartId",
                table: "cartProducts",
                newName: "IX_cartProducts_CartId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3915e851-aaf7-435c-a483-a8208d7d5201", null, "Admin", "ADMIN" },
                    { "6bf532f2-1686-48e2-bae6-c262bfa53c88", null, "Moderator", "MODERATOR" },
                    { "e1841e79-98a0-4a79-afc5-ac17a7c8ac96", null, "User", "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_cartProducts_Carts_CartId",
                table: "cartProducts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
