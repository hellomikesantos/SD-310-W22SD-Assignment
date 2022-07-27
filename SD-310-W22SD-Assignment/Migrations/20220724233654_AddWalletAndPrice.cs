using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_310_W22SD_Assignment.Migrations
{
    public partial class AddWalletAndPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Wallet",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Song",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Song");
        }
    }
}
