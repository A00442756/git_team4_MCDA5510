using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentingSystem.Migrations
{
    public partial class fkname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementGallery_Advertisements_AdvertisementAdid",
                table: "AdvertisementGallery");

            migrationBuilder.DropColumn(
                name: "Adid",
                table: "AdvertisementGallery");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertisementAdid",
                table: "AdvertisementGallery",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementGallery_Advertisements_AdvertisementAdid",
                table: "AdvertisementGallery",
                column: "AdvertisementAdid",
                principalTable: "Advertisements",
                principalColumn: "Adid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementGallery_Advertisements_AdvertisementAdid",
                table: "AdvertisementGallery");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertisementAdid",
                table: "AdvertisementGallery",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Adid",
                table: "AdvertisementGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementGallery_Advertisements_AdvertisementAdid",
                table: "AdvertisementGallery",
                column: "AdvertisementAdid",
                principalTable: "Advertisements",
                principalColumn: "Adid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
