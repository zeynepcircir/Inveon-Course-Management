using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentChapter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentChapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseChapterId = table.Column<int>(type: "int", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentChapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentChapter_CourseContents_CourseChapterId",
                        column: x => x.CourseChapterId,
                        principalTable: "CourseContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentChapter_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StudentChapter",
                columns: new[] { "Id", "CompletionDate", "CourseChapterId", "CreatedDate", "IsCompleted", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, null },
                    { 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, null },
                    { 3, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, null },
                    { 4, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, null },
                    { 5, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentChapter_CourseChapterId",
                table: "StudentChapter",
                column: "CourseChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentChapter_StudentId",
                table: "StudentChapter",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentChapter");
        }
    }
}
