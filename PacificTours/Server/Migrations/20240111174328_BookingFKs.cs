using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PacificTours.Server.Migrations
{
    /// <inheritdoc />
    public partial class BookingFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "222b4733-d23f-4f61-b940-83d0d509ac0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0f877c9-8c36-4afe-a6ac-602fcad6b2b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "362b3642-486b-4a0a-a21a-d73a9851c606", null, "client", "client" },
                    { "6a09b642-9748-4a8d-9bf0-2df3e7bd89b9", null, "manager", "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "362b3642-486b-4a0a-a21a-d73a9851c606");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a09b642-9748-4a8d-9bf0-2df3e7bd89b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "222b4733-d23f-4f61-b940-83d0d509ac0c", null, "manager", "manager" },
                    { "f0f877c9-8c36-4afe-a6ac-602fcad6b2b4", null, "client", "client" }
                });
        }
    }
}
