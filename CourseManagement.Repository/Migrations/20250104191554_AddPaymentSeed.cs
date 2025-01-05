using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "CVV", "CardNumber", "CreatedDate", "ExpiryDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "123", "4111111111111111", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12/25", null },
                    { 2, "456", "5500000000000004", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11/24", null },
                    { 3, "789", "340000000000009", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10/26", null }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CourseId", "CreatedDate", "CreditCardId", "PaymentTime", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 3, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 4, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 5, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
