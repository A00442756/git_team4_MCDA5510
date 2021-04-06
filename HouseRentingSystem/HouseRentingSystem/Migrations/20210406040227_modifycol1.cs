using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class modifycol1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementGalleries_Advertisements_AdvertisementAdid",
                table: "AdvertisementGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementGalleries",
                table: "AdvertisementGalleries");

            migrationBuilder.RenameTable(
                name: "AdvertisementGalleries",
                newName: "AdvertisementGallery");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementGalleries_AdvertisementAdid",
                table: "AdvertisementGallery",
                newName: "IX_AdvertisementGallery_AdvertisementAdid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementGallery",
                table: "AdvertisementGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementGallery_Advertisements_AdvertisementAdid",
                table: "AdvertisementGallery",
                column: "AdvertisementAdid",
                principalTable: "Advertisements",
                principalColumn: "Adid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementGallery_Advertisements_AdvertisementAdid",
                table: "AdvertisementGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementGallery",
                table: "AdvertisementGallery");

            migrationBuilder.RenameTable(
                name: "AdvertisementGallery",
                newName: "AdvertisementGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementGallery_AdvertisementAdid",
                table: "AdvertisementGalleries",
                newName: "IX_AdvertisementGalleries_AdvertisementAdid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementGalleries",
                table: "AdvertisementGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementGalleries_Advertisements_AdvertisementAdid",
                table: "AdvertisementGalleries",
                column: "AdvertisementAdid",
                principalTable: "Advertisements",
                principalColumn: "Adid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
