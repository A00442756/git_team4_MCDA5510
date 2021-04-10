using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class addcontactperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Advertisements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Advertisements");
        }
    }
}
