using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class AddClientSetToWriterAndPostSEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28dadbe7-013a-4ac0-9a86-03f82bdb93f1");

            migrationBuilder.AddColumn<bool>(
                name: "IsWriter",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa6a8387-e4ce-4809-a11c-18c826aeadc3", 0, "c032bc21-ce9a-407b-8b0d-fc135772df3e", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEJ+6Z4csMIyDh1yF3YvSx/C4vORkk8exaTs/nSMcM7Orw+Dq85pYaMeXn30ZMmvww==", null, false, "1c845e0b-95c5-4aeb-83f5-4963bd1aefac", false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa6a8387-e4ce-4809-a11c-18c826aeadc3");

            migrationBuilder.DropColumn(
                name: "IsWriter",
                table: "Clients");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28dadbe7-013a-4ac0-9a86-03f82bdb93f1", 0, "cb68a4d7-a35e-4be6-9add-17f054341978", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEALnxpiKCXi9x0LeqaVsY5hMqR0GIAp5EUJ58frp5yBtKIcg9QIlHW6yn6CXuJ1yiA==", null, false, "e18357e4-bf33-45a9-ba15-1caa176a071f", false, "Administrator" });
        }
    }
}
