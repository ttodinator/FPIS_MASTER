using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PonudaUredjajaITarifnihPaketa",
                columns: table => new
                {
                    IDPounde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDZap = table.Column<int>(type: "int", nullable: false),
                    IDKlijenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudaUredjajaITarifnihPaketa", x => x.IDPounde);
                    table.ForeignKey(
                        name: "FK_PonudaUredjajaITarifnihPaketa_Klijent_IDKlijenta",
                        column: x => x.IDKlijenta,
                        principalTable: "Klijent",
                        principalColumn: "IDKlijenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonudaUredjajaITarifnihPaketa_Zaposleni_IDZap",
                        column: x => x.IDZap,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    IDProizvodjaca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.IDProizvodjaca);
                });

            migrationBuilder.CreateTable(
                name: "Valuta",
                columns: table => new
                {
                    SifraValute = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuta", x => x.SifraValute);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPaketa",
                columns: table => new
                {
                    IDVrste = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPaketa", x => x.IDVrste);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaj",
                columns: table => new
                {
                    IDUredjaja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    IDProizvodjaca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaj", x => x.IDUredjaja);
                    table.ForeignKey(
                        name: "FK_Uredjaj_Proizvodjac_IDProizvodjaca",
                        column: x => x.IDProizvodjaca,
                        principalTable: "Proizvodjac",
                        principalColumn: "IDProizvodjaca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TekuciRacun",
                columns: table => new
                {
                    IDTR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraValute = table.Column<int>(type: "int", nullable: false),
                    DatumOtvaranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProsecanMesecniPriliv = table.Column<double>(type: "float", nullable: false),
                    ProsecanMesecniOdliv = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazivNosiocaRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TekuciRacun", x => x.IDTR);
                    table.ForeignKey(
                        name: "FK_TekuciRacun_Valuta_SifraValute",
                        column: x => x.SifraValute,
                        principalTable: "Valuta",
                        principalColumn: "SifraValute",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VrstaKredita",
                columns: table => new
                {
                    SifraVrsteKr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SifraValute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaKredita", x => x.SifraVrsteKr);
                    table.ForeignKey(
                        name: "FK_VrstaKredita_Valuta_SifraValute",
                        column: x => x.SifraValute,
                        principalTable: "Valuta",
                        principalColumn: "SifraValute",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TarifniPaket",
                columns: table => new
                {
                    IDTF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojMinuta = table.Column<int>(type: "int", nullable: false),
                    BrojPoruka = table.Column<int>(type: "int", nullable: false),
                    BrojMB = table.Column<int>(type: "int", nullable: false),
                    IDVrste = table.Column<int>(type: "int", nullable: false),
                    VrstaPaketaIDVrste = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifniPaket", x => x.IDTF);
                    table.ForeignKey(
                        name: "FK_TarifniPaket_VrstaPaketa_VrstaPaketaIDVrste",
                        column: x => x.VrstaPaketaIDVrste,
                        principalTable: "VrstaPaketa",
                        principalColumn: "IDVrste",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kredit",
                columns: table => new
                {
                    IDKr = table.Column<int>(type: "int", nullable: false),
                    SifraVrsteKr = table.Column<int>(type: "int", nullable: false),
                    IDKlijenta = table.Column<int>(type: "int", nullable: false),
                    OdobreniIznos = table.Column<double>(type: "float", nullable: false),
                    IskorisceniIznos = table.Column<double>(type: "float", nullable: false),
                    DatumPocetkaKoriscenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPocetkaOtplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumKrajaOtplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodOtplate = table.Column<int>(type: "int", nullable: false),
                    OstatakDuga = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kredit", x => new { x.IDKr, x.SifraVrsteKr, x.IDKlijenta });
                    table.ForeignKey(
                        name: "FK_Kredit_Klijent_IDKlijenta",
                        column: x => x.IDKlijenta,
                        principalTable: "Klijent",
                        principalColumn: "IDKlijenta");
                    table.ForeignKey(
                        name: "FK_Kredit_VrstaKredita_SifraVrsteKr",
                        column: x => x.SifraVrsteKr,
                        principalTable: "VrstaKredita",
                        principalColumn: "SifraVrsteKr");
                });

            migrationBuilder.CreateTable(
                name: "StavkaPonude",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPonude = table.Column<int>(type: "int", nullable: false),
                    IDUredjaja = table.Column<int>(type: "int", nullable: false),
                    UredjajIDUredjaja = table.Column<int>(type: "int", nullable: false),
                    IDTF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaPonude", x => x.Rbr);
                    table.ForeignKey(
                        name: "FK_StavkaPonude_PonudaUredjajaITarifnihPaketa_IDPonude",
                        column: x => x.IDPonude,
                        principalTable: "PonudaUredjajaITarifnihPaketa",
                        principalColumn: "IDPounde");
                    table.ForeignKey(
                        name: "FK_StavkaPonude_TarifniPaket_IDTF",
                        column: x => x.IDTF,
                        principalTable: "TarifniPaket",
                        principalColumn: "IDTF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaPonude_Uredjaj_UredjajIDUredjaja",
                        column: x => x.UredjajIDUredjaja,
                        principalTable: "Uredjaj",
                        principalColumn: "IDUredjaja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaProveruKreditneSposobnosti",
                columns: table => new
                {
                    IDZahteva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NacinDostave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDTR = table.Column<int>(type: "int", nullable: false),
                    IDKlijenta = table.Column<int>(type: "int", nullable: false),
                    IDZaposleniSalje = table.Column<int>(type: "int", nullable: false),
                    IDZaposleniPrima = table.Column<int>(type: "int", nullable: false),
                    IDKr = table.Column<int>(type: "int", nullable: false),
                    SifraVrsteKr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaProveruKreditneSposobnosti", x => x.IDZahteva);
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruKreditneSposobnosti_Klijent_IDKlijenta",
                        column: x => x.IDKlijenta,
                        principalTable: "Klijent",
                        principalColumn: "IDKlijenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruKreditneSposobnosti_Kredit_IDKr_SifraVrsteKr_IDKlijenta",
                        columns: x => new { x.IDKr, x.SifraVrsteKr, x.IDKlijenta },
                        principalTable: "Kredit",
                        principalColumns: new[] { "IDKr", "SifraVrsteKr", "IDKlijenta" });
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruKreditneSposobnosti_TekuciRacun_IDTR",
                        column: x => x.IDTR,
                        principalTable: "TekuciRacun",
                        principalColumn: "IDTR",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruKreditneSposobnosti_VrstaKredita_SifraVrsteKr",
                        column: x => x.SifraVrsteKr,
                        principalTable: "VrstaKredita",
                        principalColumn: "SifraVrsteKr");
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruKreditneSposobnosti_Zaposleni_IDZaposleniPrima",
                        column: x => x.IDZaposleniPrima,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                    table.ForeignKey(
                        name: "FK_ZahtevZaProveruKreditneSposobnosti_Zaposleni_IDZaposleniSalje",
                        column: x => x.IDZaposleniSalje,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d9d87d9-a5d8-40ec-8449-1ff6764638a5", "AQAAAAEAACcQAAAAEKq/u/L229Gtzw4OpmwX/Os9ItdtLc/m3EaINP04GbAXFaK7J5CksgFwD5ulcjbYYw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Kredit_IDKlijenta",
                table: "Kredit",
                column: "IDKlijenta");

            migrationBuilder.CreateIndex(
                name: "IX_Kredit_SifraVrsteKr",
                table: "Kredit",
                column: "SifraVrsteKr");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaUredjajaITarifnihPaketa_IDKlijenta",
                table: "PonudaUredjajaITarifnihPaketa",
                column: "IDKlijenta");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaUredjajaITarifnihPaketa_IDZap",
                table: "PonudaUredjajaITarifnihPaketa",
                column: "IDZap");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaPonude_IDPonude",
                table: "StavkaPonude",
                column: "IDPonude");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaPonude_IDTF",
                table: "StavkaPonude",
                column: "IDTF");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaPonude_UredjajIDUredjaja",
                table: "StavkaPonude",
                column: "UredjajIDUredjaja");

            migrationBuilder.CreateIndex(
                name: "IX_TarifniPaket_VrstaPaketaIDVrste",
                table: "TarifniPaket",
                column: "VrstaPaketaIDVrste");

            migrationBuilder.CreateIndex(
                name: "IX_TekuciRacun_SifraValute",
                table: "TekuciRacun",
                column: "SifraValute");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaj_IDProizvodjaca",
                table: "Uredjaj",
                column: "IDProizvodjaca");

            migrationBuilder.CreateIndex(
                name: "IX_VrstaKredita_SifraValute",
                table: "VrstaKredita",
                column: "SifraValute");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruKreditneSposobnosti_IDKlijenta",
                table: "ZahtevZaProveruKreditneSposobnosti",
                column: "IDKlijenta");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruKreditneSposobnosti_IDKr_SifraVrsteKr_IDKlijenta",
                table: "ZahtevZaProveruKreditneSposobnosti",
                columns: new[] { "IDKr", "SifraVrsteKr", "IDKlijenta" });

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruKreditneSposobnosti_IDTR",
                table: "ZahtevZaProveruKreditneSposobnosti",
                column: "IDTR");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruKreditneSposobnosti_IDZaposleniPrima",
                table: "ZahtevZaProveruKreditneSposobnosti",
                column: "IDZaposleniPrima");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruKreditneSposobnosti_IDZaposleniSalje",
                table: "ZahtevZaProveruKreditneSposobnosti",
                column: "IDZaposleniSalje");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaProveruKreditneSposobnosti_SifraVrsteKr",
                table: "ZahtevZaProveruKreditneSposobnosti",
                column: "SifraVrsteKr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkaPonude");

            migrationBuilder.DropTable(
                name: "ZahtevZaProveruKreditneSposobnosti");

            migrationBuilder.DropTable(
                name: "PonudaUredjajaITarifnihPaketa");

            migrationBuilder.DropTable(
                name: "TarifniPaket");

            migrationBuilder.DropTable(
                name: "Uredjaj");

            migrationBuilder.DropTable(
                name: "Kredit");

            migrationBuilder.DropTable(
                name: "TekuciRacun");

            migrationBuilder.DropTable(
                name: "VrstaPaketa");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "VrstaKredita");

            migrationBuilder.DropTable(
                name: "Valuta");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30d55154-6b70-4085-8469-3e56ebf836b5", "AQAAAAEAACcQAAAAEODVu14OWEkf8LbuDHfAMVw2MjYhR29tjbORTyVi/49LuRVkgH2jXf6lJS4XjhP47g==" });
        }
    }
}
