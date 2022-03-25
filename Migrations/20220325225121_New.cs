using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewellery_Shop.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_QuantityAvailable",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_QuantityAvailable",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "QuantityAvailable",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdItem",
                table: "Orders",
                column: "IdItem");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_IdItem",
                table: "Orders",
                column: "IdItem",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_IdItem",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdItem",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "FullPrice",
                table: "Orders",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantityAvailable",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_QuantityAvailable",
                table: "Orders",
                column: "QuantityAvailable");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_QuantityAvailable",
                table: "Orders",
                column: "QuantityAvailable",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
