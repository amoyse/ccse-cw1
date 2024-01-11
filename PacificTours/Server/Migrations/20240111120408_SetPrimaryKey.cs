using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PacificTours.Server.Migrations
{
    /// <inheritdoc />
    public partial class SetPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bf33d4-6c0d-413c-b18b-aa660a7814b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3b361d-35c4-418d-9f51-1c36a9b051bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04184fe3-e565-42e9-b184-3b77fc1d0df2", null, "client", "client" },
                    { "c5901222-4aa7-42cb-a633-6af75f4cd4f8", null, "manager", "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04184fe3-e565-42e9-b184-3b77fc1d0df2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5901222-4aa7-42cb-a633-6af75f4cd4f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2bf33d4-6c0d-413c-b18b-aa660a7814b2", null, "manager", "manager" },
                    { "ea3b361d-35c4-418d-9f51-1c36a9b051bf", null, "client", "client" }
                });
        }
    }
}
