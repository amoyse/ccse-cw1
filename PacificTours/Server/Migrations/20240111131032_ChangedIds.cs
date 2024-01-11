using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PacificTours.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04184fe3-e565-42e9-b184-3b77fc1d0df2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5901222-4aa7-42cb-a633-6af75f4cd4f8");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TourID",
                table: "TourBookings",
                newName: "TourId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "TourBookings",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "TourBookingID",
                table: "TourBookings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TourID",
                table: "Tour",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Payments",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "Payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "Hotels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "HotelBookings",
                newName: "HotelId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "HotelBookings",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "HotelBookingID",
                table: "HotelBookings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16c53f39-0a82-495f-aec3-472be49015fd", null, "manager", "manager" },
                    { "1cc05255-d39b-4977-8698-b85aece2a4ff", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c53f39-0a82-495f-aec3-472be49015fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cc05255-d39b-4977-8698-b85aece2a4ff");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "TourBookings",
                newName: "TourID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "TourBookings",
                newName: "BookingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TourBookings",
                newName: "TourBookingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tour",
                newName: "TourID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Payments",
                newName: "BookingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "PaymentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hotels",
                newName: "HotelID");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "HotelBookings",
                newName: "HotelID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "HotelBookings",
                newName: "BookingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HotelBookings",
                newName: "HotelBookingID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bookings",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04184fe3-e565-42e9-b184-3b77fc1d0df2", null, "client", "client" },
                    { "c5901222-4aa7-42cb-a633-6af75f4cd4f8", null, "manager", "manager" }
                });
        }
    }
}
