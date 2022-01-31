using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class data4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    IDServisa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.IDServisa);
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaAktivacijuServisa",
                columns: table => new
                {
                    IDZahtevaAS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odobreno = table.Column<bool>(type: "bit", nullable: false),
                    IDZap = table.Column<int>(type: "int", nullable: false),
                    IDUgovora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaAktivacijuServisa", x => x.IDZahtevaAS);
                    table.ForeignKey(
                        name: "FK_ZahtevZaAktivacijuServisa_Ugovor_IDUgovora",
                        column: x => x.IDUgovora,
                        principalTable: "Ugovor",
                        principalColumn: "IDUgovora");
                    table.ForeignKey(
                        name: "FK_ZahtevZaAktivacijuServisa_Zaposleni_IDZap",
                        column: x => x.IDZap,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaTehnickomPodrskom",
                columns: table => new
                {
                    IDZahtevaTP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Oodbreno = table.Column<bool>(type: "bit", nullable: false),
                    IDZap = table.Column<int>(type: "int", nullable: false),
                    IDUgovora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaTehnickomPodrskom", x => x.IDZahtevaTP);
                    table.ForeignKey(
                        name: "FK_ZahtevZaTehnickomPodrskom_Ugovor_IDUgovora",
                        column: x => x.IDUgovora,
                        principalTable: "Ugovor",
                        principalColumn: "IDUgovora");
                    table.ForeignKey(
                        name: "FK_ZahtevZaTehnickomPodrskom_Zaposleni_IDZap",
                        column: x => x.IDZap,
                        principalTable: "Zaposleni",
                        principalColumn: "IDZap");
                });

            migrationBuilder.CreateTable(
                name: "StavkaZahtevaAS",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    IDZahtevaAS = table.Column<int>(type: "int", nullable: false),
                    IDServisa = table.Column<int>(type: "int", nullable: false),
                    RokIsporuke = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaZahtevaAS", x => new { x.Rbr, x.IDZahtevaAS });
                    table.ForeignKey(
                        name: "FK_StavkaZahtevaAS_Servis_IDServisa",
                        column: x => x.IDServisa,
                        principalTable: "Servis",
                        principalColumn: "IDServisa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaZahtevaAS_ZahtevZaAktivacijuServisa_IDZahtevaAS",
                        column: x => x.IDZahtevaAS,
                        principalTable: "ZahtevZaAktivacijuServisa",
                        principalColumn: "IDZahtevaAS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaZahtevaTP",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    IDZahtevaTP = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServisIDServisa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaZahtevaTP", x => new { x.Rbr, x.IDZahtevaTP });
                    table.ForeignKey(
                        name: "FK_StavkaZahtevaTP_Servis_ServisIDServisa",
                        column: x => x.ServisIDServisa,
                        principalTable: "Servis",
                        principalColumn: "IDServisa");
                    table.ForeignKey(
                        name: "FK_StavkaZahtevaTP_ZahtevZaTehnickomPodrskom_IDZahtevaTP",
                        column: x => x.IDZahtevaTP,
                        principalTable: "ZahtevZaTehnickomPodrskom",
                        principalColumn: "IDZahtevaTP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PotvrdaORealizacijiPodrske",
                columns: table => new
                {
                    IDPotvrde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uradjeno = table.Column<bool>(type: "bit", nullable: false),
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    IDZahtevaTP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotvrdaORealizacijiPodrske", x => x.IDPotvrde);
                    table.ForeignKey(
                        name: "FK_PotvrdaORealizacijiPodrske_StavkaZahtevaTP_Rbr_IDZahtevaTP",
                        columns: x => new { x.Rbr, x.IDZahtevaTP },
                        principalTable: "StavkaZahtevaTP",
                        principalColumns: new[] { "Rbr", "IDZahtevaTP" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotvrdaORealizacijiPodrske_ZahtevZaTehnickomPodrskom_IDZahtevaTP",
                        column: x => x.IDZahtevaTP,
                        principalTable: "ZahtevZaTehnickomPodrskom",
                        principalColumn: "IDZahtevaTP");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff16ea5b-ef69-43a1-91c3-7377c9762398", "AQAAAAEAACcQAAAAEFgR4FfsH1d/wZdecJXFqR5SjKPrV4R2OadiNezKPbXVHS2l1z4vX/6zX60ypCMhXA==" });

            migrationBuilder.CreateIndex(
                name: "IX_PotvrdaORealizacijiPodrske_IDZahtevaTP",
                table: "PotvrdaORealizacijiPodrske",
                column: "IDZahtevaTP");

            migrationBuilder.CreateIndex(
                name: "IX_PotvrdaORealizacijiPodrske_Rbr_IDZahtevaTP",
                table: "PotvrdaORealizacijiPodrske",
                columns: new[] { "Rbr", "IDZahtevaTP" });

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahtevaAS_IDServisa",
                table: "StavkaZahtevaAS",
                column: "IDServisa");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahtevaAS_IDZahtevaAS",
                table: "StavkaZahtevaAS",
                column: "IDZahtevaAS");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahtevaTP_IDZahtevaTP",
                table: "StavkaZahtevaTP",
                column: "IDZahtevaTP");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahtevaTP_ServisIDServisa",
                table: "StavkaZahtevaTP",
                column: "ServisIDServisa");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaAktivacijuServisa_IDUgovora",
                table: "ZahtevZaAktivacijuServisa",
                column: "IDUgovora");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaAktivacijuServisa_IDZap",
                table: "ZahtevZaAktivacijuServisa",
                column: "IDZap");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaTehnickomPodrskom_IDUgovora",
                table: "ZahtevZaTehnickomPodrskom",
                column: "IDUgovora");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaTehnickomPodrskom_IDZap",
                table: "ZahtevZaTehnickomPodrskom",
                column: "IDZap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotvrdaORealizacijiPodrske");

            migrationBuilder.DropTable(
                name: "StavkaZahtevaAS");

            migrationBuilder.DropTable(
                name: "StavkaZahtevaTP");

            migrationBuilder.DropTable(
                name: "ZahtevZaAktivacijuServisa");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "ZahtevZaTehnickomPodrskom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a11d81dd-6f14-4dbd-9b8b-a4ba91c56899", "AQAAAAEAACcQAAAAEF86Dfi2WPUtkA0Cdeil/upywlra5weoG4xlLV+0UbtwxxSksBrWk8fG00wXUp/gbw==" });
        }
    }
}
