using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class AddedTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymViewModelTrainer");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Gyms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "GymTrainer",
                columns: table => new
                {
                    GymsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTrainer", x => new { x.GymsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_GymTrainer_Gyms_GymsId",
                        column: x => x.GymsId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainer_Trainers_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ddbef1b-9d8d-4926-9c42-d47f3561021a", 0, "339a01df-5d99-41db-b124-5690ae188ab9", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEDOtS9rlLb39IJ34ejSzJFApnA3RTJsZYIg+0Y/w2A0OW3GWDIvmBE9KC5/rhahccw==", null, false, "9f53dd67-a654-43af-95df-f1d2fce23d96", null, false, "Administrator" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "Bench Press" },
                    { 2, null, "Deadlift" },
                    { 3, null, "Squat" },
                    { 4, null, "Boxing" },
                    { 5, null, "Pull ups" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria, Sofia, Mladost", null, "Iron Fitness" },
                    { 2, "Bulgaria, Sofia, Druzba", null, "Gold Gym" },
                    { 3, "Bulgaria, Sofia, Obelya", null, "MMA Arena" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Email", "Experience", "ImageUrl", "IsAvailable", "Name", "Telephone" },
                values: new object[,]
                {
                    { 1, "ronnie@test.com", "+20 years", null, true, "Ronnie Colman", "0888777666" },
                    { 2, "lee.bruce@test.com", "15 years", null, true, "Bruce Lee", "0809777111" },
                    { 3, "rockybalboa@test.com", "10 years", null, true, "Rocky Balboa", "0899555222" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainer_TrainersId",
                table: "GymTrainer",
                column: "TrainersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymTrainer");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ddbef1b-9d8d-4926-9c42-d47f3561021a");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Gyms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GymViewModelTrainer",
                columns: table => new
                {
                    GymsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymViewModelTrainer", x => new { x.GymsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_GymViewModelTrainer_Gyms_GymsId",
                        column: x => x.GymsId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymViewModelTrainer_Trainers_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymViewModelTrainer_TrainersId",
                table: "GymViewModelTrainer",
                column: "TrainersId");
        }
    }
}
