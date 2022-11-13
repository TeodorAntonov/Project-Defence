using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class ClientsCollectionChangedFromUserCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e925af2-06a6-483b-aa01-ce13c3c7b73a");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId1",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6dcc154b-369a-4f9e-aa93-cbd7014b4140", 0, "7b3ab3c4-4cfa-42aa-8c0d-7c7ccdba86b1", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEPRbYyxcnRikbYVjYr3qL7zTH7NjWy9u89OHueQytXexnpStBpyOddE1UzLWVz5Ppg==", null, false, "c7cae74f-dfa5-4d26-81a8-a155a6121b13", false, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TrainerId",
                table: "Clients",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TrainerId1",
                table: "Clients",
                column: "TrainerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Trainers_TrainerId",
                table: "Clients",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Trainers_TrainerId1",
                table: "Clients",
                column: "TrainerId1",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Trainers_TrainerId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Trainers_TrainerId1",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TrainerId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TrainerId1",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6dcc154b-369a-4f9e-aa93-cbd7014b4140");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TrainerId1",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e925af2-06a6-483b-aa01-ce13c3c7b73a", 0, "bb7238ac-ac39-4e8a-8a4b-155041d0f2a9", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEABrrsLcVO6+5bB2CDxQN9PdUK9Vx7vNtA0gFYsTRwyQNuz40jacgGkkku8Cur7XvQ==", null, false, "47c3d1e7-cd16-48bf-92a3-7a9cb6b51cee", null, false, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }
    }
}
