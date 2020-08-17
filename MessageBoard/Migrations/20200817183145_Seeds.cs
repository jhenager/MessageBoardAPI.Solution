using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ParentThreadThreadId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Boards_ParentBoardBoardId",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Users_UserId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Threads_ParentBoardBoardId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ParentThreadThreadId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ParentBoardBoardId",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "ParentThreadThreadId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Threads",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentBoardId",
                table: "Threads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentThreadId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Title" },
                values: new object[,]
                {
                    { 1, "Politics" },
                    { 2, "Religions" },
                    { 3, "Objectively Best Music Genres" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreationDate", "UserName" },
                values: new object[] { 1, new DateTime(2020, 8, 17, 11, 31, 45, 67, DateTimeKind.Local).AddTicks(4750), "TestName" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CreationDate", "ParentBoardId", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2020, 8, 17, 11, 31, 45, 61, DateTimeKind.Local).AddTicks(5620), 1, "Test Message", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CreationDate", "ParentThreadId", "PostBody", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2020, 8, 17, 11, 31, 45, 66, DateTimeKind.Local).AddTicks(7010), 1, "Lorem Ipsum", "Test Message", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Threads_ParentBoardId",
                table: "Threads",
                column: "ParentBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentThreadId",
                table: "Posts",
                column: "ParentThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ParentThreadId",
                table: "Posts",
                column: "ParentThreadId",
                principalTable: "Threads",
                principalColumn: "ThreadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Boards_ParentBoardId",
                table: "Threads",
                column: "ParentBoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Users_UserId",
                table: "Threads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ParentThreadId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Boards_ParentBoardId",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Users_UserId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Threads_ParentBoardId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ParentThreadId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ParentBoardId",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "ParentThreadId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Threads",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentBoardBoardId",
                table: "Threads",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentThreadThreadId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Threads_ParentBoardBoardId",
                table: "Threads",
                column: "ParentBoardBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentThreadThreadId",
                table: "Posts",
                column: "ParentThreadThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ParentThreadThreadId",
                table: "Posts",
                column: "ParentThreadThreadId",
                principalTable: "Threads",
                principalColumn: "ThreadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Boards_ParentBoardBoardId",
                table: "Threads",
                column: "ParentBoardBoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Users_UserId",
                table: "Threads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
