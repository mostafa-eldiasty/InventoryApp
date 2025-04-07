using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.CheckConstraint("CK_InventoryItem_StockQuantity_Min", "[StockQuantity] >= 0");
                });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "Id", "Category", "Name", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Electronics", "Laptop", 5 },
                    { 2, "Electronics", "Television", 15 },
                    { 3, "Furniture", "Table", 25 },
                    { 4, "Furniture", "Chair", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItem");
        }
    }
}
