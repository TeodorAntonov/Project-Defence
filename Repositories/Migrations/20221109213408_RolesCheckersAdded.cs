using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class RolesCheckersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66d57c86-b900-4152-baf0-38d1a6c7a213");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdministrator",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrainer",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6042d310-87e9-4b1a-8195-963d67c69dce", 0, "29adc20a-bb0e-4188-8d90-2366939a33ce", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEPCPWvAIx7i6gtoMxxC48OhOZuJnOKb1YhM0Dg/5X+q+jLmj3cBFy0MzNOzF9+LhTw==", null, false, "4a81c4d5-0c2d-43b0-a566-ed93fae6eed5", null, false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "6042d310-87e9-4b1a-8195-963d67c69dce");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6042d310-87e9-4b1a-8195-963d67c69dce");

            migrationBuilder.DropColumn(
                name: "IsAdministrator",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsTrainer",
                table: "Clients");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66d57c86-b900-4152-baf0-38d1a6c7a213", 0, "9a0b1232-ecdf-4766-98c6-595aadf9ddcc", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEMHSLtGdb1U4QCdkMi/jLDl4ACvGty6PI8ViPvKgJS6Qz9kuG0EEdVWSThdwJSUw0g==", null, false, "08a196df-3d65-4e15-8b28-e1241a193aaa", null, false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "66d57c86-b900-4152-baf0-38d1a6c7a213");
        }
    }
}
