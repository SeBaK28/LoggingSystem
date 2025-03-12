using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CartProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Carts_CartId",
                table: "CartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36f5a434-31a7-4f6a-9f28-966ee7000d2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "562985f0-5d06-4001-82bc-21afb7931085");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7849cfc-40d4-45bf-b580-071db4e216ee");

            migrationBuilder.RenameTable(
                name: "CartProduct",
                newName: "cartProducts");

            migrationBuilder.RenameIndex(
                name: "IX_CartProduct_CartId",
                table: "cartProducts",
                newName: "IX_cartProducts_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartProducts",
                table: "cartProducts",
                column: "CartProductId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartProducts_Carts_CartId",
                table: "cartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartProducts",
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

            migrationBuilder.RenameTable(
                name: "cartProducts",
                newName: "CartProduct");

            migrationBuilder.RenameIndex(
                name: "IX_cartProducts_CartId",
                table: "CartProduct",
                newName: "IX_CartProduct_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                column: "CartProductId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36f5a434-31a7-4f6a-9f28-966ee7000d2f", null, "User", "User" },
                    { "562985f0-5d06-4001-82bc-21afb7931085", null, "Admin", "ADMIN" },
                    { "b7849cfc-40d4-45bf-b580-071db4e216ee", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Carts_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
