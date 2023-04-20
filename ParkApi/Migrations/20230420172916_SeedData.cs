using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Park",
                columns: new[] { "ParkId", "Name", "National", "State" },
                values: new object[,]
                {
                    { 1, "Crater Lake", true, "Oregon" },
                    { 2, "Ainsworth", false, "Oregon" },
                    { 3, "Bates", false, "Oregon" },
                    { 4, "Angel Island", false, "California" },
                    { 5, "Van Damme", false, "California" },
                    { 6, "Yosemite", true, "California" },
                    { 7, "Joshua Tree", true, "California" },
                    { 8, "Big Bend", true, "Texas" },
                    { 9, "Big Spring", false, "Texas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 9);
        }
    }
}
