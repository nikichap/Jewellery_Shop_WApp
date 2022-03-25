using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewellery_Shop.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Items_ItemId",
                table: "Favourites");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Favourites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Items_ItemId",
                table: "Favourites",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Items_ItemId",
                table: "Favourites");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Items_ItemId",
                table: "Favourites",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
