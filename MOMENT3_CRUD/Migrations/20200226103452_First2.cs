using Microsoft.EntityFrameworkCore.Migrations;

namespace MOMENT3_CRUD.Migrations
{
    public partial class First2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "CDs");

            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "CDs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "CDs");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
