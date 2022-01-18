using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trip_it.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "klijent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezimeKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_klijent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "lokacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lokacija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ponuda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lokacijaID = table.Column<int>(type: "int", nullable: true),
                    cena = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ponuda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ponuda_lokacija_lokacijaID",
                        column: x => x.lokacijaID,
                        principalTable: "lokacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rezervacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    klijentID = table.Column<int>(type: "int", nullable: true),
                    ponudaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_rezervacija_klijent_klijentID",
                        column: x => x.klijentID,
                        principalTable: "klijent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rezervacija_ponuda_ponudaID",
                        column: x => x.ponudaID,
                        principalTable: "ponuda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ponuda_lokacijaID",
                table: "ponuda",
                column: "lokacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacija_klijentID",
                table: "rezervacija",
                column: "klijentID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacija_ponudaID",
                table: "rezervacija",
                column: "ponudaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rezervacija");

            migrationBuilder.DropTable(
                name: "klijent");

            migrationBuilder.DropTable(
                name: "ponuda");

            migrationBuilder.DropTable(
                name: "lokacija");
        }
    }
}
