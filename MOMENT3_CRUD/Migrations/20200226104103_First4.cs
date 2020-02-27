using Microsoft.EntityFrameworkCore.Migrations;

namespace MOMENT3_CRUD.Migrations
{
    public partial class First4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Genres");

            migrationBuilder.AddColumn<string>(
                name: "Genre_Name",
                table: "Genres",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre_Name",
                table: "CDs",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre_Name",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Genre_Name",
                table: "CDs");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
