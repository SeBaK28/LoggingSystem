using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Products_ProductsListProductId",
                table: "CartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_ProductsListProductId",
                table: "CartProduct");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06035dcb-9dd0-4b82-8c52-990e76adae30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42e0ff1b-37bd-4911-8b0b-dd1572246500");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed875c5-30f1-45f0-9008-16e9690bc466");

            migrationBuilder.RenameColumn(
                name: "ProductsListProductId",
                table: "CartProduct",
                newName: "Pieces");

            migrationBuilder.AddColumn<int>(
                name: "CartProductId",
                table: "CartProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "PrivePerPiece",
                table: "CartProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartProduct",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_CartId",
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

            migrationBuilder.DropColumn(
                name: "CartProductId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "PrivePerPiece",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartProduct");

            migrationBuilder.RenameColumn(
                name: "Pieces",
                table: "CartProduct",
                newName: "ProductsListProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                columns: new[] { "CartId", "ProductsListProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06035dcb-9dd0-4b82-8c52-990e76adae30", null, "Moderator", "MODERATOR" },
                    { "42e0ff1b-37bd-4911-8b0b-dd1572246500", null, "User", "User" },
                    { "5ed875c5-30f1-45f0-9008-16e9690bc466", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductsListProductId",
                table: "CartProduct",
                column: "ProductsListProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Products_ProductsListProductId",
                table: "CartProduct",
                column: "ProductsListProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
