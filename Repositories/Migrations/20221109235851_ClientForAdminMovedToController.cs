using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class ClientForAdminMovedToController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6042d310-87e9-4b1a-8195-963d67c69dce");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8749f9a1-25ad-4072-bb61-725e2d03a44c", 0, "d4031e7f-39f4-46a9-acf0-96369158473e", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEILYEGcUNXcblCq1Awv+8tADHWP6pA6/JeKAlbyyw21h4J6grwbBt3N6eAGFTCMRqQ==", null, false, "91adaee9-3b6d-402e-a85e-7a837fcc6565", null, false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8749f9a1-25ad-4072-bb61-725e2d03a44c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6042d310-87e9-4b1a-8195-963d67c69dce", 0, "29adc20a-bb0e-4188-8d90-2366939a33ce", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEPCPWvAIx7i6gtoMxxC48OhOZuJnOKb1YhM0Dg/5X+q+jLmj3cBFy0MzNOzF9+LhTw==", null, false, "4a81c4d5-0c2d-43b0-a566-ed93fae6eed5", null, false, "Administrator" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AgeStarted", "ClientNotes", "CurrentAge", "CurrentHeight", "CurrentWeight", "HeightStarted", "IsAdministrator", "IsTrainer", "SetGoals", "Trainer", "TypeOfSport", "UserId", "WeightStarted", "WorkoutPlan" },
                values: new object[] { 1, null, null, null, null, null, null, false, false, null, null, null, "6042d310-87e9-4b1a-8195-963d67c69dce", null, null });
        }
    }
}
