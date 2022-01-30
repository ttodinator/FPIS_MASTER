using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class removedpassfake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordCustom",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2dc1485-cf68-454e-b951-687d9de9c0c2", "AQAAAAEAACcQAAAAEK9TAAC3ytoDKIk90ye6YZ5oC8SsSjO//0Zj3/8Fim3WQz6i41GyCjCEZs+P13wCng==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordCustom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8def28b6-ceb9-484f-8c40-3711c2d38a19", "AQAAAAEAACcQAAAAEJryyh1M0p7lZkFQEOsDYTy0U0y+yyzhm5uwil/CtUm3H/eri6Hct9io7147BFBstw==" });
        }
    }
}
