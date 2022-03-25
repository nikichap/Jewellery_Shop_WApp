using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewellery_Shop.Migrations
{
    public partial class WithoutItemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Items_ItemId",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_ItemId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Favourites");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Favourites",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "Favourites");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Favourites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_ItemId",
                table: "Favourites",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Items_ItemId",
                table: "Favourites",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
