using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class ClientAdminSetDirectly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9c92a19-afb8-4a31-8878-bf45c38da5c4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29edcca3-2453-4e57-848a-a5456e0c357b", 0, "fa68493a-126e-4852-a3a0-e521c8654f4a", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHVDVlBWfpcvUwj7El3u3+rKPZDDSgeiIFsBTD/i5K27n3Mg6oEfoSy0unTh7QWoCQ==", null, false, "3bcf339e-9b85-4996-98a5-3db829b6c395", null, false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29edcca3-2453-4e57-848a-a5456e0c357b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b9c92a19-afb8-4a31-8878-bf45c38da5c4", 0, "055e4f6c-01ef-4c76-9bf7-c4451effeb84", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEBfS7+k2hLIDIzA7EiQylwTHUAxs21q53/ZzJ+mMKueqPS3739L/RfXdEV56RnhyMg==", null, false, "ec061536-ea19-4e52-8242-42b8f3130d08", null, false, "Administrator" });
        }
    }
}
