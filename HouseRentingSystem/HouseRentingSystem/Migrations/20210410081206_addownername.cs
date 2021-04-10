using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class addownername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseownerName",
                table: "Contracts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseownerName",
                table: "Contracts");
        }
    }
}
