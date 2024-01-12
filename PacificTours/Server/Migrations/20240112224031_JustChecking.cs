using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PacificTours.Server.Migrations
{
    /// <inheritdoc />
    public partial class JustChecking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f45354-e2fd-463d-8d5f-ae6286e89fcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f706a541-cbbc-457b-8c78-a33be8c49dd3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e10ac4d2-1920-4d11-bce9-a86ac1e83878", null, "manager", "manager" },
                    { "e79b0b16-5b4b-44f1-a843-4e73087c26be", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e10ac4d2-1920-4d11-bce9-a86ac1e83878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e79b0b16-5b4b-44f1-a843-4e73087c26be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2f45354-e2fd-463d-8d5f-ae6286e89fcb", null, "client", "client" },
                    { "f706a541-cbbc-457b-8c78-a33be8c49dd3", null, "manager", "manager" }
                });
        }
    }
}
