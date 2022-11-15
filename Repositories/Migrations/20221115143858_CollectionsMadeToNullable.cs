using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class CollectionsMadeToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21e6ac71-dc3b-4c5a-9dea-06fceac8c539");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "47d8cdfd-3402-408a-9370-9f721b48b60f", 0, "9d9bc4ed-2651-434d-9add-6b4645593ed5", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEL4NKxPmNtfvOaNIo5DxGL56SMypvm3aWBV3x8/oKJ7mwcmZLYkD/bPmDTOQaIaPww==", null, false, "dade3bdd-d421-42ec-b7b9-2adfcaa5e1b6", false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47d8cdfd-3402-408a-9370-9f721b48b60f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21e6ac71-dc3b-4c5a-9dea-06fceac8c539", 0, "ae41966e-a98d-4512-8e00-e7d6309a4b0f", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEI2toZJL8CLxH5igeDRJmISq6wigx1p0Q0tq1WMQYYbEdgw88h0nWpEd/W9G3a7xUA==", null, false, "a4df9e55-ff4b-4c05-aff5-fe171ad3df61", false, "Administrator" });
        }
    }
}
