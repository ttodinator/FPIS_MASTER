using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class custompass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "921ca629-39e9-4223-bd3a-8b735fedb9b3", "AQAAAAEAACcQAAAAEFntU4TCbctMD9e+T5WxmnTn7ZvugGx+2n5DOVIFVO3Si5rkvdI/+cn5hgQFqkmqng==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordCustom",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09966a85-d4eb-4ca1-a416-4ac14bec592b", "AQAAAAEAACcQAAAAEPo1DcMeGcUjKiExnAV8s57ugB87QdJYGkHXKPVtHWbQ6HybGgL6pdVoReEqLdONbw==" });
        }
    }
}
