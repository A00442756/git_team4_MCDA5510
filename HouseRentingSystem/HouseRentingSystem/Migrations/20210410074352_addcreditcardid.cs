using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class addcreditcardid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Contracts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContractsModel",
                columns: table => new
                {
                    Contractid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseownerName = table.Column<string>(nullable: true),
                    TenantName = table.Column<string>(nullable: true),
                    Startdate = table.Column<DateTime>(nullable: false),
                    Adid = table.Column<int>(nullable: false),
                    Monthlyrent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsModel", x => x.Contractid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractsModel");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Contracts");
        }
    }
}
