using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class TrainerEntiryImageStringAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0bcbf74c-5e36-4194-b2c0-ee1643ee22fe", 0, "156954b6-4c73-4b9d-85f3-b5a7d7844b60", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEAFZ3CshO0A/SXodufr74u1JbvesKbell6Z3C4JjDm+F4MPxX+GFNH8U20kXGQCyA==", null, false, "dbfd7c92-70b4-4cf7-b591-05f9eb023f17", false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bcbf74c-5e36-4194-b2c0-ee1643ee22fe");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trainers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7ed24e6-c43c-41fe-adf3-c08866c7d41f", 0, "f67a19a7-952f-4b20-953a-5cf4a87e0ce8", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEIN7pVrXSN2HoFXsgwmu8zuywK8lmAHfnQ99exdVKTBmxXP2fHmGUcZGh/ESw1qqgA==", null, false, "6ee69317-a0f2-4536-930f-40a904da516e", false, "Administrator" });
        }
    }
}
