using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class add2col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementGalleries_Advertisements_AdvertisementsAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementGalleries_AdvertisementsAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropColumn(
                name: "AdvertisementsAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "AdvertisementGalleries");

            migrationBuilder.AddColumn<int>(
                name: "Adid",
                table: "AdvertisementGalleries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementAdid",
                table: "AdvertisementGalleries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementGalleries_AdvertisementAdid",
                table: "AdvertisementGalleries",
                column: "AdvertisementAdid");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementGalleries_Advertisements_AdvertisementAdid",
                table: "AdvertisementGalleries",
                column: "AdvertisementAdid",
                principalTable: "Advertisements",
                principalColumn: "Adid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementGalleries_Advertisements_AdvertisementAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementGalleries_AdvertisementAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropColumn(
                name: "Adid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropColumn(
                name: "AdvertisementAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementsAdid",
                table: "AdvertisementGalleries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "AdvertisementGalleries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementGalleries_AdvertisementsAdid",
                table: "AdvertisementGalleries",
                column: "AdvertisementsAdid");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementGalleries_Advertisements_AdvertisementsAdid",
                table: "AdvertisementGalleries",
                column: "AdvertisementsAdid",
                principalTable: "Advertisements",
                principalColumn: "Adid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
