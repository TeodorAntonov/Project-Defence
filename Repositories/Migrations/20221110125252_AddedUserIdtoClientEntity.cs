using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class AddedUserIdtoClientEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8749f9a1-25ad-4072-bb61-725e2d03a44c");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trainers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "502ad5c1-e534-4c05-9adf-d47d6bd7aa65", 0, "ea08e008-4900-461b-9c37-0c046225df22", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEkQpNzr8ZoBq/smmn5OxE7oYRJsMw3vVJV/TnKqjJUdb/6HpgpQ/I0PS3E54uNYBw==", null, false, "6dbe732a-6b01-4cc0-a97a-8045f4f295df", null, false, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "502ad5c1-e534-4c05-9adf-d47d6bd7aa65");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trainers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8749f9a1-25ad-4072-bb61-725e2d03a44c", 0, "d4031e7f-39f4-46a9-acf0-96369158473e", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEILYEGcUNXcblCq1Awv+8tADHWP6pA6/JeKAlbyyw21h4J6grwbBt3N6eAGFTCMRqQ==", null, false, "91adaee9-3b6d-402e-a85e-7a837fcc6565", null, false, "Administrator" });
        }
    }
}
