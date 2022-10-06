using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imgeneus.Authentication.Migrations
{
    public partial class RemoveShopItemCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ShopItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Count",
                table: "ShopItems",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
