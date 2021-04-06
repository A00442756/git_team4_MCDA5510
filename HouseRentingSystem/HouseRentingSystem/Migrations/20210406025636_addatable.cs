using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class addatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    AdvertisementsAdid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementGalleries_Advertisements_AdvertisementsAdid",
                        column: x => x.AdvertisementsAdid,
                        principalTable: "Advertisements",
                        principalColumn: "Adid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementGalleries_AdvertisementsAdid",
                table: "AdvertisementGalleries",
                column: "AdvertisementsAdid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementGalleries");
        }
    }
}
