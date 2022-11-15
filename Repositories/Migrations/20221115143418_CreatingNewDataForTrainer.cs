using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class CreatingNewDataForTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4785b614-9a1f-4eff-923b-91849601b420");

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21e6ac71-dc3b-4c5a-9dea-06fceac8c539", 0, "ae41966e-a98d-4512-8e00-e7d6309a4b0f", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEI2toZJL8CLxH5igeDRJmISq6wigx1p0Q0tq1WMQYYbEdgw88h0nWpEd/W9G3a7xUA==", null, false, "a4df9e55-ff4b-4c05-aff5-fe171ad3df61", false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Experience", "Name", "Telephone" },
                values: new object[] { "ronnie@test.com", "+20 years", "Ronnie Colman", "0888777666" });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Experience", "Name", "Telephone" },
                values: new object[] { "lee.bruce@test.com", "15 years", "Bruce Lee", "0809777111" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Email", "Experience", "ImageUrl", "IsAvailable", "Name", "Telephone", "UserId" },
                values: new object[] { 4, "rockybalboa@test.com", "10 years", null, true, "Rocky Balboa", "0899555222", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21e6ac71-dc3b-4c5a-9dea-06fceac8c539");

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4785b614-9a1f-4eff-923b-91849601b420", 0, "8b6d785c-fdcf-4e37-b781-28d319bf053f", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEPGVqSrgs3CQHjRGOlYtObGq8yk0jsR4rjCEdWc/JSBsfLc8DDFmqJ9Myr36JDLHYw==", null, false, "6c3f807f-40fb-4846-b994-d09114f2b8cd", false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Experience", "Name", "Telephone" },
                values: new object[] { "lee.bruce@test.com", "15 years", "Bruce Lee", "0809777111" });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Experience", "Name", "Telephone" },
                values: new object[] { "rockybalboa@test.com", "10 years", "Rocky Balboa", "0899555222" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Email", "Experience", "ImageUrl", "IsAvailable", "Name", "Telephone", "UserId" },
                values: new object[] { 1, "ronnie@test.com", "+20 years", null, true, "Ronnie Colman", "0888777666", null });
        }
    }
}
