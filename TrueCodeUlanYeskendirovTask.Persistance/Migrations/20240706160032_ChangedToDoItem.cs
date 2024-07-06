using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrueCodeUlanYeskendirovTask.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToDoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Priorities_PriorityId",
                table: "ToDoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Users_UserId",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ToDoItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "ToDoItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Priorities_PriorityId",
                table: "ToDoItems",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Level");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Users_UserId",
                table: "ToDoItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Priorities_PriorityId",
                table: "ToDoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Users_UserId",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ToDoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "ToDoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Priorities_PriorityId",
                table: "ToDoItems",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Level",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Users_UserId",
                table: "ToDoItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
