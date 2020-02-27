using Microsoft.EntityFrameworkCore.Migrations;

namespace MOMENT3_CRUD.Migrations
{
    public partial class First3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "CDs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
