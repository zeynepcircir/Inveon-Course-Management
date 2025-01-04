using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AverageRating", "CategoryId", "CreatedDate", "Description", "ImageUrl", "InstructorId", "Language", "Level", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 4.5, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the basics of programming with this beginner-friendly course.", "programming-course.jpg", 1, "English", "Beginner", 49.99m, "Introduction to Programming", null },
                    { 2, 4.7999999999999998, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Take your design skills to the next level with this advanced course.", "design-course.jpg", 1, "English", "Advanced", 79.99m, "Advanced Graphic Design", null },
                    { 3, 4.7000000000000002, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master the art of digital marketing with this comprehensive course.", "marketing-course.jpg", 1, "English", "Intermediate", 99.99m, "Digital Marketing Mastery", null },
                    { 4, 4.5999999999999996, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the essentials of starting and managing your own business.", "business-course.jpg", 1, "English", "Beginner", 59.99m, "Entrepreneurship Essentials", null },
                    { 5, 4.9000000000000004, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore the world of scientific research with practical techniques.", "science-course.jpg", 1, "English", "Intermediate", 69.99m, "Scientific Research Techniques", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
