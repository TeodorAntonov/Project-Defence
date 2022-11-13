using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class AddedDescriptionToExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "922b5208-4e92-47db-9255-4e3154246f4b");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "856ddbb8-39e4-4b81-ae53-47d35b405a1e", 0, "1e8b80e0-acbc-4ffd-80a9-823c2fb2c005", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHVphScis5BpP/z+oNP1wVyz2AEgddVbzsKUwAHudjdpzyXiOXBNaHMcNjg3RKsteA==", null, false, "46be8c88-ccd3-4454-8181-6a2491eb06c5", null, false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "856ddbb8-39e4-4b81-ae53-47d35b405a1e");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercises");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "922b5208-4e92-47db-9255-4e3154246f4b", 0, "07a00b63-661c-414e-bef8-c9753ed1df76", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEDFqLy4aIkL7zEwNI7/Nf5n2EheIPvqff5asV4p9x/IUi5RGdiLuaiWY8Lv6t9rjqQ==", null, false, "bc3419cc-030b-4d5e-9ea8-108984e3277f", null, false, "Administrator" });
        }
    }
}
