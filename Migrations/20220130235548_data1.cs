using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class data1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesto",
                columns: table => new
                {
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesto", x => x.PostanskiBroj);
                });

            migrationBuilder.CreateTable(
                name: "Operater",
                columns: table => new
                {
                    IDOperatera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operater", x => x.IDOperatera);
                });

            migrationBuilder.CreateTable(
                name: "OrganizacionaJedinica",
                columns: table => new
                {
                    IDOrgJed = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacionaJedinica", x => x.IDOrgJed);
                });

            migrationBuilder.CreateTable(
                name: "Ulica",
                columns: table => new
                {
                    IDUlice = table.Column<int>(type: "int", nullable: false),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulica", x => new { x.IDUlice, x.PostanskiBroj });
                    table.ForeignKey(
                        name: "FK_Ulica_Mesto_PostanskiBroj",
                        column: x => x.PostanskiBroj,
                        principalTable: "Mesto",
                        principalColumn: "PostanskiBroj");
                });

            migrationBuilder.CreateTable(
                name: "Pozicija",
                columns: table => new
                {
                    IDPoz = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPoz1 = table.Column<int>(type: "int", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDOrgJed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicija", x => x.IDPoz);
                    table.ForeignKey(
                        name: "FK_Pozicija_OrganizacionaJedinica_IDOrgJed",
                        column: x => x.IDOrgJed,
                        principalTable: "OrganizacionaJedinica",
                        principalColumn: "IDOrgJed",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pozicija_Pozicija_IDPoz1",
                        column: x => x.IDPoz1,
                        principalTable: "Pozicija",
                        principalColumn: "IDPoz");
                });

            migrationBuilder.CreateTable(
                name: "Broj",
                columns: table => new
                {
                    BrojAdrese = table.Column<int>(type: "int", nullable: false),
                    IDUlice = table.Column<int>(type: "int", nullable: false),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broj", x => new { x.PostanskiBroj, x.IDUlice, x.BrojAdrese });
                    table.ForeignKey(
                        name: "FK_Broj_Mesto_PostanskiBroj",
                        column: x => x.PostanskiBroj,
                        principalTable: "Mesto",
                        principalColumn: "PostanskiBroj",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Broj_Ulica_IDUlice_PostanskiBroj",
                        columns: x => new { x.IDUlice, x.PostanskiBroj },
                        principalTable: "Ulica",
                        principalColumns: new[] { "IDUlice", "PostanskiBroj" });
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    IDZap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDZPoz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.IDZap);
                    table.ForeignKey(
                        name: "FK_Zaposleni_Pozicija_IDZPoz",
                        column: x => x.IDZPoz,
                        principalTable: "Pozicija",
                        principalColumn: "IDPoz",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PotencijalniKlijent",
                columns: table => new
                {
                    IDPotKlijenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZaposleniSaljeId = table.Column<int>(type: "int", nullable: false),
                    ZaposleniPrimaId = table.Column<int>(type: "int", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotencijalniKlijent", x => x.IDPotKlijenta);
                    table.ForeignKey(
                        name: "FK_PotencijalniKlijent_Zaposleni_ZaposleniPrimaId",
                        column: x => x.ZaposleniPrimaId,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                    table.ForeignKey(
                        name: "FK_PotencijalniKlijent_Zaposleni_ZaposleniSaljeId",
                        column: x => x.ZaposleniSaljeId,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    IDKlijenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebStrana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodinaOsnivanja = table.Column<int>(type: "int", nullable: false),
                    SifraDel = table.Column<int>(type: "int", nullable: false),
                    BrojAdrese = table.Column<int>(type: "int", nullable: false),
                    IDUlice = table.Column<int>(type: "int", nullable: false),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false),
                    IDPotKlijenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.IDKlijenta);
                    table.ForeignKey(
                        name: "FK_Klijent_Broj_PostanskiBroj_IDUlice_BrojAdrese",
                        columns: x => new { x.PostanskiBroj, x.IDUlice, x.BrojAdrese },
                        principalTable: "Broj",
                        principalColumns: new[] { "PostanskiBroj", "IDUlice", "BrojAdrese" });
                    table.ForeignKey(
                        name: "FK_Klijent_Delatnost_SifraDel",
                        column: x => x.SifraDel,
                        principalTable: "Delatnost",
                        principalColumn: "SifraDel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijent_Mesto_PostanskiBroj",
                        column: x => x.PostanskiBroj,
                        principalTable: "Mesto",
                        principalColumn: "PostanskiBroj",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijent_PotencijalniKlijent_IDPotKlijenta",
                        column: x => x.IDPotKlijenta,
                        principalTable: "PotencijalniKlijent",
                        principalColumn: "IDPotKlijenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijent_Ulica_PostanskiBroj_IDUlice",
                        columns: x => new { x.PostanskiBroj, x.IDUlice },
                        principalTable: "Ulica",
                        principalColumns: new[] { "IDUlice", "PostanskiBroj" });
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaPodacima",
                columns: table => new
                {
                    IDZahteva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrZaposlenih = table.Column<int>(type: "int", nullable: false),
                    BrSIMKartica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDZap = table.Column<int>(type: "int", nullable: false),
                    IDKlijenta = table.Column<int>(type: "int", nullable: true),
                    IDOperatera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaPodacima", x => x.IDZahteva);
                    table.ForeignKey(
                        name: "FK_ZahtevZaPodacima_Klijent_IDKlijenta",
                        column: x => x.IDKlijenta,
                        principalTable: "Klijent",
                        principalColumn: "IDKlijenta");
                    table.ForeignKey(
                        name: "FK_ZahtevZaPodacima_Operater_IDOperatera",
                        column: x => x.IDOperatera,
                        principalTable: "Operater",
                        principalColumn: "IDOperatera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtevZaPodacima_Zaposleni_IDZap",
                        column: x => x.IDZap,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30d55154-6b70-4085-8469-3e56ebf836b5", "AQAAAAEAACcQAAAAEODVu14OWEkf8LbuDHfAMVw2MjYhR29tjbORTyVi/49LuRVkgH2jXf6lJS4XjhP47g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Broj_IDUlice_PostanskiBroj",
                table: "Broj",
                columns: new[] { "IDUlice", "PostanskiBroj" });

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_IDPotKlijenta",
                table: "Klijent",
                column: "IDPotKlijenta");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_PostanskiBroj_IDUlice_BrojAdrese",
                table: "Klijent",
                columns: new[] { "PostanskiBroj", "IDUlice", "BrojAdrese" });

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_SifraDel",
                table: "Klijent",
                column: "SifraDel");

            migrationBuilder.CreateIndex(
                name: "IX_PotencijalniKlijent_ZaposleniPrimaId",
                table: "PotencijalniKlijent",
                column: "ZaposleniPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_PotencijalniKlijent_ZaposleniSaljeId",
                table: "PotencijalniKlijent",
                column: "ZaposleniSaljeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozicija_IDOrgJed",
                table: "Pozicija",
                column: "IDOrgJed");

            migrationBuilder.CreateIndex(
                name: "IX_Pozicija_IDPoz1",
                table: "Pozicija",
                column: "IDPoz1");

            migrationBuilder.CreateIndex(
                name: "IX_Ulica_PostanskiBroj",
                table: "Ulica",
                column: "PostanskiBroj");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaPodacima_IDKlijenta",
                table: "ZahtevZaPodacima",
                column: "IDKlijenta");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaPodacima_IDOperatera",
                table: "ZahtevZaPodacima",
                column: "IDOperatera");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaPodacima_IDZap",
                table: "ZahtevZaPodacima",
                column: "IDZap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleni_IDZPoz",
                table: "Zaposleni",
                column: "IDZPoz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZahtevZaPodacima");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Operater");

            migrationBuilder.DropTable(
                name: "Broj");

            migrationBuilder.DropTable(
                name: "PotencijalniKlijent");

            migrationBuilder.DropTable(
                name: "Ulica");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.DropTable(
                name: "Mesto");

            migrationBuilder.DropTable(
                name: "Pozicija");

            migrationBuilder.DropTable(
                name: "OrganizacionaJedinica");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2dc1485-cf68-454e-b951-687d9de9c0c2", "AQAAAAEAACcQAAAAEK9TAAC3ytoDKIk90ye6YZ5oC8SsSjO//0Zj3/8Fim3WQz6i41GyCjCEZs+P13wCng==" });
        }
    }
}
