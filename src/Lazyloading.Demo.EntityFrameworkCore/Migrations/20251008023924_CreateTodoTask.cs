using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lazyloading.Demo.Migrations
{
    /// <inheritdoc />
    public partial class CreateTodoTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTodoTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTodoTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppChecklistItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TodoTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppChecklistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppChecklistItems_AppTodoTasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "AppTodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUploadFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TodoTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUploadFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUploadFiles_AppTodoTasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "AppTodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppChecklistItems_TodoTaskId",
                table: "AppChecklistItems",
                column: "TodoTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUploadFiles_TodoTaskId",
                table: "AppUploadFiles",
                column: "TodoTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppChecklistItems");

            migrationBuilder.DropTable(
                name: "AppUploadFiles");

            migrationBuilder.DropTable(
                name: "AppTodoTasks");
        }
    }
}
