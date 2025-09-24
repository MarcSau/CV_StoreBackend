using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreBackend.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class NameUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_typeID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_typeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "typeID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "Products",
                newName: "productTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productTypeId",
                table: "Products",
                column: "productTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_productTypeId",
                table: "Products",
                column: "productTypeId",
                principalTable: "ProductTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_productTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_productTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "productTypeId",
                table: "Products",
                newName: "ProductType");

            migrationBuilder.AddColumn<int>(
                name: "typeID",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "typeID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_typeID",
                table: "Products",
                column: "typeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_typeID",
                table: "Products",
                column: "typeID",
                principalTable: "ProductTypes",
                principalColumn: "ID");
        }
    }
}
