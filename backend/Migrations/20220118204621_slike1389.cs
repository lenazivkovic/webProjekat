using Microsoft.EntityFrameworkCore.Migrations;

namespace trip_it.Migrations
{
    public partial class slike1389 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slika",
                table: "lokacija",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika",
                table: "lokacija");
        }
    }
}
