using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class AddedApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "502ad5c1-e534-4c05-9adf-d47d6bd7aa65");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "922b5208-4e92-47db-9255-4e3154246f4b", 0, "07a00b63-661c-414e-bef8-c9753ed1df76", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEDFqLy4aIkL7zEwNI7/Nf5n2EheIPvqff5asV4p9x/IUi5RGdiLuaiWY8Lv6t9rjqQ==", null, false, "bc3419cc-030b-4d5e-9ea8-108984e3277f", null, false, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "922b5208-4e92-47db-9255-4e3154246f4b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "502ad5c1-e534-4c05-9adf-d47d6bd7aa65", 0, "ea08e008-4900-461b-9c37-0c046225df22", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEkQpNzr8ZoBq/smmn5OxE7oYRJsMw3vVJV/TnKqjJUdb/6HpgpQ/I0PS3E54uNYBw==", null, false, "6dbe732a-6b01-4cc0-a97a-8045f4f295df", null, false, "Administrator" });
        }
    }
}
