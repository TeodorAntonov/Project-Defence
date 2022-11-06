using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class ClientEntityCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ddbef1b-9d8d-4926-9c42-d47f3561021a");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgeStarted = table.Column<int>(type: "int", nullable: true),
                    WeightStarted = table.Column<double>(type: "float", nullable: true),
                    HeightStarted = table.Column<double>(type: "float", nullable: true),
                    TypeOfSport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetGoals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trainer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAge = table.Column<int>(type: "int", nullable: true),
                    CurrentWeight = table.Column<double>(type: "float", nullable: true),
                    CurrentHeight = table.Column<double>(type: "float", nullable: true),
                    ClientNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc1aa6fc-8d38-44da-a226-3544bf6b0102", 0, "9bcfd11d-d2fe-494f-81b9-6499ff6418f5", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEMCX+Ln7ph0eazmBaNDR5qYyFE0AbItAQBwPtbseDDVwhwVQVUj1Y8/TwsmeEx/3Pw==", null, false, "0452eb58-640d-428a-b50f-6a8fefe2444a", null, false, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc1aa6fc-8d38-44da-a226-3544bf6b0102");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ddbef1b-9d8d-4926-9c42-d47f3561021a", 0, "339a01df-5d99-41db-b124-5690ae188ab9", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEDOtS9rlLb39IJ34ejSzJFApnA3RTJsZYIg+0Y/w2A0OW3GWDIvmBE9KC5/rhahccw==", null, false, "9f53dd67-a654-43af-95df-f1d2fce23d96", null, false, "Administrator" });
        }
    }
}
