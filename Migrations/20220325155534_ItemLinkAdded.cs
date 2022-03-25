using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewellery_Shop.Migrations
{
    public partial class ItemLinkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Items",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Items");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Items",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
