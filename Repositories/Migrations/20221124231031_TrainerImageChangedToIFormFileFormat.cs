using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class TrainerImageChangedToIFormFileFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b135de03-d169-482b-aad7-048ae53209f4");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trainers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7ed24e6-c43c-41fe-adf3-c08866c7d41f", 0, "f67a19a7-952f-4b20-953a-5cf4a87e0ce8", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEIN7pVrXSN2HoFXsgwmu8zuywK8lmAHfnQ99exdVKTBmxXP2fHmGUcZGh/ESw1qqgA==", null, false, "6ee69317-a0f2-4536-930f-40a904da516e", false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7ed24e6-c43c-41fe-adf3-c08866c7d41f");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b135de03-d169-482b-aad7-048ae53209f4", 0, "31fe5a5e-c36d-4453-97a8-b0b7837f5644", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEAfK+L39hLNphqoYgzNiRhiP5O3n57+hiKoRwKOqaSFUr4iZ5QayzG6B9i/msy2VhQ==", null, false, "3a6270f9-d5b1-4d0a-b678-b68d35463795", false, "Administrator" });
        }
    }
}
