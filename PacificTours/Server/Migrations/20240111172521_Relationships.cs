using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PacificTours.Server.Migrations
{
    /// <inheritdoc />
    public partial class Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c53f39-0a82-495f-aec3-472be49015fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cc05255-d39b-4977-8698-b85aece2a4ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba0a534e-40ff-4850-80c8-424b8bdd81c5", null, "manager", "manager" },
                    { "f3a5b5f1-b45f-452f-b128-f7f861a11159", null, "client", "client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_BookingId",
                table: "TourBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_TourId",
                table: "TourBookings",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_BookingId",
                table: "HotelBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_HotelId",
                table: "HotelBookings",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Bookings_BookingId",
                table: "HotelBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Hotels_HotelId",
                table: "HotelBookings",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Bookings_BookingId",
                table: "TourBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Tour_TourId",
                table: "TourBookings",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Bookings_BookingId",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Hotels_HotelId",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Bookings_BookingId",
                table: "TourBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Tour_TourId",
                table: "TourBookings");

            migrationBuilder.DropIndex(
                name: "IX_TourBookings_BookingId",
                table: "TourBookings");

            migrationBuilder.DropIndex(
                name: "IX_TourBookings_TourId",
                table: "TourBookings");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_HotelBookings_BookingId",
                table: "HotelBookings");

            migrationBuilder.DropIndex(
                name: "IX_HotelBookings_HotelId",
                table: "HotelBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba0a534e-40ff-4850-80c8-424b8bdd81c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a5b5f1-b45f-452f-b128-f7f861a11159");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16c53f39-0a82-495f-aec3-472be49015fd", null, "manager", "manager" },
                    { "1cc05255-d39b-4977-8698-b85aece2a4ff", null, "client", "client" }
                });
        }
    }
}
