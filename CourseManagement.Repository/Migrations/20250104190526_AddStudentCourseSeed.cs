using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentCourseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CompletionDate", "CourseId", "CreatedDate", "IsCompleted", "LastAccessDate", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 3, null, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 4, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 5, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
