using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class NewControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 11, 31, 45, 66, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 11, 31, 45, 61, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 11, 31, 45, 67, DateTimeKind.Local).AddTicks(4750));
        }
    }
}
