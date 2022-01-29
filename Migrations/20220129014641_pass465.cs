using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class pass465 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21705a17-6091-427b-ba9b-37628c68efd9", "AQAAAAEAACcQAAAAEG6jZc1peD4yTcA6vKEIQVz5jG2jZB/grdCMq6yFgXjGH14K6M1LJ+UkCl5H+ilXVg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "14c626e1-fc74-4f73-9cdf-a8fcc00bbe18", "aaaa" });
        }
    }
}
