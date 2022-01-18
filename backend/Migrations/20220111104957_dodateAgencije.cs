using Microsoft.EntityFrameworkCore.Migrations;

namespace trip_it.Migrations
{
    public partial class dodateAgencije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "agencijaID",
                table: "ponuda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "agencija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeAgencije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agencija", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ponuda_agencijaID",
                table: "ponuda",
                column: "agencijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ponuda_agencija_agencijaID",
                table: "ponuda",
                column: "agencijaID",
                principalTable: "agencija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ponuda_agencija_agencijaID",
                table: "ponuda");

            migrationBuilder.DropTable(
                name: "agencija");

            migrationBuilder.DropIndex(
                name: "IX_ponuda_agencijaID",
                table: "ponuda");

            migrationBuilder.DropColumn(
                name: "agencijaID",
                table: "ponuda");
        }
    }
}
