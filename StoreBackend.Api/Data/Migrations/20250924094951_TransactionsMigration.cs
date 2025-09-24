using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreBackend.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CurrentStock", "Name", "Price", "ProductType", "typeID" },
                values: new object[] { 1, 25, "DnD 2025 Rulebook", 29.989999999999998, 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_productID",
                table: "Transactions",
                column: "productID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
