using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ButcherShop.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyForMeatTypesInProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeatTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeatTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "MeatTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "MeatTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "MeatTypeId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeatTypeId",
                table: "Products",
                column: "MeatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeatTypes_MeatTypeId",
                table: "Products",
                column: "MeatTypeId",
                principalTable: "MeatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeatTypes_MeatTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MeatTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MeatTypeId",
                table: "Products");
        }
    }
}
