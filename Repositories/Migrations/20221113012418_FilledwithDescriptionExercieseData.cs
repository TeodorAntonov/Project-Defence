using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDefence.Data.Migrations
{
    public partial class FilledwithDescriptionExercieseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "856ddbb8-39e4-4b81-ae53-47d35b405a1e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e925af2-06a6-483b-aa01-ce13c3c7b73a", 0, "bb7238ac-ac39-4e8a-8a4b-155041d0f2a9", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEABrrsLcVO6+5bB2CDxQN9PdUK9Vx7vNtA0gFYsTRwyQNuz40jacgGkkku8Cur7XvQ==", null, false, "47c3d1e7-cd16-48bf-92a3-7a9cb6b51cee", null, false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Push the bar while laying on a benech. You need to put your back streigth and tide on the bench.");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Put your feet under the bar then grab the bar and lift it from the ground. Dont be in hurry!");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Put your shoulders under the bar then grab the bar and and get it out of the rack and sqaut. Dont be in hurry!");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Try to defence yourself while the opponent is beating. When you see a chance fight back.");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Jump and and grab the bar however you like, just try to pull yourself as high as possible.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e925af2-06a6-483b-aa01-ce13c3c7b73a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrainerId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "856ddbb8-39e4-4b81-ae53-47d35b405a1e", 0, "1e8b80e0-acbc-4ffd-80a9-823c2fb2c005", "admin@mail.com", false, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHVphScis5BpP/z+oNP1wVyz2AEgddVbzsKUwAHudjdpzyXiOXBNaHMcNjg3RKsteA==", null, false, "46be8c88-ccd3-4454-8181-6a2491eb06c5", null, false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: null);
        }
    }
}
