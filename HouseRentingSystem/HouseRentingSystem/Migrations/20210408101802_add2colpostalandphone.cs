using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class add2colpostalandphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNum",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SignInModel",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    RememberMe = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignInModel", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignInModel");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNum",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Advertisements");
        }
    }
}
