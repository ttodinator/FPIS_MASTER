using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class data3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proracun",
                columns: table => new
                {
                    IDProracuna = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Popust = table.Column<double>(type: "float", nullable: false),
                    CenaSaPopustom = table.Column<double>(type: "float", nullable: false),
                    IDZaposleniSalje = table.Column<int>(type: "int", nullable: false),
                    IDZaposleniPrima = table.Column<int>(type: "int", nullable: false),
                    IDPonude = table.Column<int>(type: "int", nullable: false),
                    PonudaUredjajaITarifnihPaketaIDPounde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proracun", x => x.IDProracuna);
                    table.ForeignKey(
                        name: "FK_Proracun_PonudaUredjajaITarifnihPaketa_PonudaUredjajaITarifnihPaketaIDPounde",
                        column: x => x.PonudaUredjajaITarifnihPaketaIDPounde,
                        principalTable: "PonudaUredjajaITarifnihPaketa",
                        principalColumn: "IDPounde",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proracun_Zaposleni_IDZaposleniPrima",
                        column: x => x.IDZaposleniPrima,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                    table.ForeignKey(
                        name: "FK_Proracun_Zaposleni_IDZaposleniSalje",
                        column: x => x.IDZaposleniSalje,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaProveruTehnickihUsluga",
                columns: table => new
                {
                    IDZahteva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odobreno = table.Column<bool>(type: "bit", nullable: false),
                    IDZaposleniSalje = table.Column<int>(type: "int", nullable: false),
                    IDZaposleniPrima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaProveruTehnickihUsluga", x => x.IDZahteva);
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruTehnickihUsluga_Zaposleni_IDZaposleniPrima",
                        column: x => x.IDZaposleniPrima,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruTehnickihUsluga_Zaposleni_IDZaposleniSalje",
                        column: x => x.IDZaposleniSalje,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.CreateTable(
                name: "Ponuda",
                columns: table => new
                {
                    IDPonude = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDProracuna = table.Column<int>(type: "int", nullable: false),
                    RokPrihvatanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponuda", x => x.IDPonude);
                    table.ForeignKey(
                        name: "FK_Ponuda_Proracun_IDProracuna",
                        column: x => x.IDProracuna,
                        principalTable: "Proracun",
                        principalColumn: "IDProracuna",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaProracuna",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    IDProracuna = table.Column<int>(type: "int", nullable: false),
                    IDUredjaja = table.Column<int>(type: "int", nullable: false),
                    IDTF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaProracuna", x => new { x.Rbr, x.IDProracuna });
                    table.ForeignKey(
                        name: "FK_StavkaProracuna_Proracun_IDProracuna",
                        column: x => x.IDProracuna,
                        principalTable: "Proracun",
                        principalColumn: "IDProracuna",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaProracuna_TarifniPaket_IDTF",
                        column: x => x.IDTF,
                        principalTable: "TarifniPaket",
                        principalColumn: "IDTF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaProracuna_Uredjaj_IDUredjaja",
                        column: x => x.IDUredjaja,
                        principalTable: "Uredjaj",
                        principalColumn: "IDUredjaja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaZahteva",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    IDZahteva = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaZahteva", x => new { x.Rbr, x.IDZahteva });
                    table.ForeignKey(
                        name: "FK_StavkaZahteva_ZahtevZaProveruTehnickihUsluga_IDZahteva",
                        column: x => x.IDZahteva,
                        principalTable: "ZahtevZaProveruTehnickihUsluga",
                        principalColumn: "IDZahteva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ugovor",
                columns: table => new
                {
                    IDUgovora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDZaposleniPotpisuje = table.Column<int>(type: "int", nullable: false),
                    IDZaposleniProverava = table.Column<int>(type: "int", nullable: false),
                    IDPonude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovor", x => x.IDUgovora);
                    table.ForeignKey(
                        name: "FK_Ugovor_Ponuda_IDPonude",
                        column: x => x.IDPonude,
                        principalTable: "Ponuda",
                        principalColumn: "IDPonude",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ugovor_Zaposleni_IDZaposleniPotpisuje",
                        column: x => x.IDZaposleniPotpisuje,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                    table.ForeignKey(
                        name: "FK_Ugovor_Zaposleni_IDZaposleniProverava",
                        column: x => x.IDZaposleniProverava,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.CreateTable(
                name: "StavkaPonudeSklapanjeUgovora",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    IDPonude = table.Column<int>(type: "int", nullable: false),
                    RbrStavkaProracuna = table.Column<int>(type: "int", nullable: false),
                    IDProracuna = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaPonudeSklapanjeUgovora", x => new { x.Rbr, x.IDPonude });
                    table.ForeignKey(
                        name: "FK_StavkaPonudeSklapanjeUgovora_Ponuda_IDPonude",
                        column: x => x.IDPonude,
                        principalTable: "Ponuda",
                        principalColumn: "IDPonude",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaPonudeSklapanjeUgovora_Proracun_IDProracuna",
                        column: x => x.IDProracuna,
                        principalTable: "Proracun",
                        principalColumn: "IDProracuna");
                    table.ForeignKey(
                        name: "FK_StavkaPonudeSklapanjeUgovora_StavkaProracuna_Rbr_IDProracuna",
                        columns: x => new { x.Rbr, x.IDProracuna },
                        principalTable: "StavkaProracuna",
                        principalColumns: new[] { "Rbr", "IDProracuna" });
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a11d81dd-6f14-4dbd-9b8b-a4ba91c56899", "AQAAAAEAACcQAAAAEF86Dfi2WPUtkA0Cdeil/upywlra5weoG4xlLV+0UbtwxxSksBrWk8fG00wXUp/gbw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_IDProracuna",
                table: "Ponuda",
                column: "IDProracuna");

            migrationBuilder.CreateIndex(
                name: "IX_Proracun_IDZaposleniPrima",
                table: "Proracun",
                column: "IDZaposleniPrima");

            migrationBuilder.CreateIndex(
                name: "IX_Proracun_IDZaposleniSalje",
                table: "Proracun",
                column: "IDZaposleniSalje");

            migrationBuilder.CreateIndex(
                name: "IX_Proracun_PonudaUredjajaITarifnihPaketaIDPounde",
                table: "Proracun",
                column: "PonudaUredjajaITarifnihPaketaIDPounde");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaPonudeSklapanjeUgovora_IDPonude",
                table: "StavkaPonudeSklapanjeUgovora",
                column: "IDPonude");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaPonudeSklapanjeUgovora_IDProracuna",
                table: "StavkaPonudeSklapanjeUgovora",
                column: "IDProracuna");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaPonudeSklapanjeUgovora_Rbr_IDProracuna",
                table: "StavkaPonudeSklapanjeUgovora",
                columns: new[] { "Rbr", "IDProracuna" });

            migrationBuilder.CreateIndex(
                name: "IX_StavkaProracuna_IDProracuna",
                table: "StavkaProracuna",
                column: "IDProracuna");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaProracuna_IDTF",
                table: "StavkaProracuna",
                column: "IDTF");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaProracuna_IDUredjaja",
                table: "StavkaProracuna",
                column: "IDUredjaja");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahteva_IDZahteva",
                table: "StavkaZahteva",
                column: "IDZahteva");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovor_IDPonude",
                table: "Ugovor",
                column: "IDPonude");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovor_IDZaposleniPotpisuje",
                table: "Ugovor",
                column: "IDZaposleniPotpisuje");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovor_IDZaposleniProverava",
                table: "Ugovor",
                column: "IDZaposleniProverava");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruTehnickihUsluga_IDZaposleniPrima",
                table: "ZahtevZaProveruTehnickihUsluga",
                column: "IDZaposleniPrima");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruTehnickihUsluga_IDZaposleniSalje",
                table: "ZahtevZaProveruTehnickihUsluga",
                column: "IDZaposleniSalje");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkaPonudeSklapanjeUgovora");

            migrationBuilder.DropTable(
                name: "StavkaZahteva");

            migrationBuilder.DropTable(
                name: "Ugovor");

            migrationBuilder.DropTable(
                name: "StavkaProracuna");

            migrationBuilder.DropTable(
                name: "ZahtevZaProveruTehnickihUsluga");

            migrationBuilder.DropTable(
                name: "Ponuda");

            migrationBuilder.DropTable(
                name: "Proracun");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d9d87d9-a5d8-40ec-8449-1ff6764638a5", "AQAAAAEAACcQAAAAEKq/u/L229Gtzw4OpmwX/Os9ItdtLc/m3EaINP04GbAXFaK7J5CksgFwD5ulcjbYYw==" });
        }
    }
}
