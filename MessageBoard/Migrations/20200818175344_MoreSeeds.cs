using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class MoreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 18, 10, 53, 43, 610, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 18, 10, 53, 43, 606, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CreationDate", "ParentBoardId", "Title", "UserId" },
                values: new object[,]
                {
                    { 24, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5210), 1, "Test Message", 1 },
                    { 23, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5200), 1, "Test Message", 1 },
                    { 22, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5200), 1, "Test Message", 1 },
                    { 21, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5200), 1, "Test Message", 1 },
                    { 20, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5190), 1, "Test Message", 1 },
                    { 19, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5190), 1, "Test Message", 1 },
                    { 18, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5180), 1, "Test Message", 1 },
                    { 17, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5180), 1, "Test Message", 1 },
                    { 16, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5180), 1, "Test Message", 1 },
                    { 15, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5170), 1, "Test Message", 1 },
                    { 14, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5170), 1, "Test Message", 1 },
                    { 13, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5160), 1, "Test Message", 1 },
                    { 12, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5160), 1, "Test Message", 1 },
                    { 11, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5160), 1, "Test Message", 1 },
                    { 10, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5150), 1, "Test Message", 1 },
                    { 9, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5150), 1, "Test Message", 1 },
                    { 8, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5140), 1, "Test Message", 1 },
                    { 7, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5140), 1, "Test Message", 1 },
                    { 6, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5130), 1, "Test Message", 1 },
                    { 5, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5130), 1, "Test Message", 1 },
                    { 4, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5120), 1, "Test Message", 1 },
                    { 3, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5120), 1, "Test Message", 1 },
                    { 2, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5090), 1, "Test Message", 1 },
                    { 25, new DateTime(2020, 8, 18, 10, 53, 43, 609, DateTimeKind.Local).AddTicks(5210), 1, "Test Message", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 18, 10, 53, 43, 610, DateTimeKind.Local).AddTicks(8010));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 14, 21, 11, 294, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 14, 21, 11, 261, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 14, 21, 11, 295, DateTimeKind.Local).AddTicks(1400));
        }
    }
}
