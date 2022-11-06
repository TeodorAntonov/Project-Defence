using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class ClientAdminSetDirectly2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29edcca3-2453-4e57-848a-a5456e0c357b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66d57c86-b900-4152-baf0-38d1a6c7a213", 0, "9a0b1232-ecdf-4766-98c6-595aadf9ddcc", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEMHSLtGdb1U4QCdkMi/jLDl4ACvGty6PI8ViPvKgJS6Qz9kuG0EEdVWSThdwJSUw0g==", null, false, "08a196df-3d65-4e15-8b28-e1241a193aaa", null, false, "Administrator" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AgeStarted", "ClientNotes", "CurrentAge", "CurrentHeight", "CurrentWeight", "HeightStarted", "SetGoals", "Trainer", "TypeOfSport", "UserId", "WeightStarted", "WorkoutPlan" },
                values: new object[] { 1, null, null, null, null, null, null, null, null, null, "66d57c86-b900-4152-baf0-38d1a6c7a213", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66d57c86-b900-4152-baf0-38d1a6c7a213");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29edcca3-2453-4e57-848a-a5456e0c357b", 0, "fa68493a-126e-4852-a3a0-e521c8654f4a", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHVDVlBWfpcvUwj7El3u3+rKPZDDSgeiIFsBTD/i5K27n3Mg6oEfoSy0unTh7QWoCQ==", null, false, "3bcf339e-9b85-4996-98a5-3db829b6c395", null, false, "Administrator" });
        }
    }
}
