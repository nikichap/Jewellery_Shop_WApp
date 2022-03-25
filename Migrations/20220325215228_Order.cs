using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewellery_Shop.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Orders",
                newName: "ChoosenItem");

            migrationBuilder.AddColumn<int>(
                name: "IdItem",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_QuantityAvailable",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_QuantityAvailable",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdItem",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ChoosenItem",
                table: "Orders",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
