using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.szukits.hu/storage/images/cache/data/2023.10./tronok_harca_b1_2023-max1920-max1080.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.szukits.hu/storage/images/cache/data/Kiadok/alexandra/kiralyok_csataja-rate_bg400-rate_bg600.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.szukits.hu/storage/images/cache/data/Kiadok/alexandra/kardok-vihara-b-rate_bg400-rate_bg600.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.szukits.hu/storage/images/cache/data/Kiadok/alexandra/varjak_lakomaja-max1920-max1080.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.szukits.hu/storage/images/cache/data/Kiadok/alexandra/sarkanyok-tanca-max1920-max1080.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");
        }
    }
}
