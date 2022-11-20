using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class AddTitleToPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa6a8387-e4ce-4809-a11c-18c826aeadc3");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b135de03-d169-482b-aad7-048ae53209f4", 0, "31fe5a5e-c36d-4453-97a8-b0b7837f5644", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEAfK+L39hLNphqoYgzNiRhiP5O3n57+hiKoRwKOqaSFUr4iZ5QayzG6B9i/msy2VhQ==", null, false, "3a6270f9-d5b1-4d0a-b678-b68d35463795", false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b135de03-d169-482b-aad7-048ae53209f4");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa6a8387-e4ce-4809-a11c-18c826aeadc3", 0, "c032bc21-ce9a-407b-8b0d-fc135772df3e", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEJ+6Z4csMIyDh1yF3YvSx/C4vORkk8exaTs/nSMcM7Orw+Dq85pYaMeXn30ZMmvww==", null, false, "1c845e0b-95c5-4aeb-83f5-4963bd1aefac", false, "Administrator" });
        }
    }
}
