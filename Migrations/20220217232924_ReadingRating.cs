using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDKLibrary.Migrations
{
    public partial class ReadingRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReadingRate",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingRate",
                table: "Book");
        }
    }
}
