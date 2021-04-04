using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Adid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(nullable: false),
                    Ondisplay = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Streetname = table.Column<string>(nullable: true),
                    Streetnum = table.Column<string>(nullable: true),
                    Bedroomsnum = table.Column<int>(nullable: false),
                    Bathroomsnum = table.Column<int>(nullable: false),
                    Hydro = table.Column<bool>(nullable: false),
                    Heat = table.Column<bool>(nullable: false),
                    Water = table.Column<bool>(nullable: false),
                    Internet = table.Column<bool>(nullable: false),
                    Parkingnum = table.Column<int>(nullable: false),
                    Agreementtype = table.Column<string>(nullable: true),
                    Moveindate = table.Column<DateTime>(nullable: false),
                    Petfriendly = table.Column<bool>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Furnished = table.Column<bool>(nullable: false),
                    Laundry = table.Column<bool>(nullable: false),
                    Dishwasher = table.Column<bool>(nullable: false),
                    Fridge = table.Column<bool>(nullable: false),
                    Airconditioning = table.Column<bool>(nullable: false),
                    Smokingpermit = table.Column<bool>(nullable: false),
                    Postdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Adid);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Contractid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Houseownerid = table.Column<int>(nullable: false),
                    Tenantid = table.Column<int>(nullable: false),
                    Startdate = table.Column<DateTime>(nullable: false),
                    Enddate = table.Column<DateTime>(nullable: false),
                    Adid = table.Column<int>(nullable: false),
                    Deal = table.Column<bool>(nullable: true),
                    Monthlyrent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Contractid);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Cid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(nullable: false),
                    Cardnumber = table.Column<string>(nullable: true),
                    Cardtype = table.Column<string>(nullable: true),
                    Expireyear = table.Column<string>(nullable: true),
                    Expiremonth = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Imgid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<byte[]>(nullable: true),
                    Adid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Imgid);
                });

            migrationBuilder.CreateTable(
                name: "StarLists",
                columns: table => new
                {
                    Starid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(nullable: false),
                    Adid = table.Column<int>(nullable: false),
                    Stardate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarLists", x => x.Starid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    Emailaddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "StarLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
