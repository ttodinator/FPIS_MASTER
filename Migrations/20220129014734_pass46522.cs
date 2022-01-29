using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIS.Migrations
{
    public partial class pass46522 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CellphoneNumber", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserEmail", "UserName" },
                values: new object[] { 1, 0, null, "09966a85-d4eb-4ca1-a416-4ac14bec592b", null, "admin@gmail.com", false, false, null, "Petar", null, null, "AQAAAAEAACcQAAAAEPo1DcMeGcUjKiExnAV8s57ugB87QdJYGkHXKPVtHWbQ6HybGgL6pdVoReEqLdONbw==", "1234567890", false, null, "Todic", false, null, "admin1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CellphoneNumber", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserEmail", "UserName" },
                values: new object[] { 3, 0, null, "21705a17-6091-427b-ba9b-37628c68efd9", null, "admin@gmail.com", false, false, null, "Petar", null, null, "AQAAAAEAACcQAAAAEG6jZc1peD4yTcA6vKEIQVz5jG2jZB/grdCMq6yFgXjGH14K6M1LJ+UkCl5H+ilXVg==", "1234567890", false, null, "Todic", false, null, "admin1" });
        }
    }
}
