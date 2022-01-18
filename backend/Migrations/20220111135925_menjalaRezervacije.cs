using Microsoft.EntityFrameworkCore.Migrations;

namespace trip_it.Migrations
{
    public partial class menjalaRezervacije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "brojDana",
                table: "rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "brojOsoba",
                table: "rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brojDana",
                table: "rezervacija");

            migrationBuilder.DropColumn(
                name: "brojOsoba",
                table: "rezervacija");
        }
    }
}
