namespace PacificTours.Server.Entities;

public class HotelBooking
{
    public int HotelBookingID { get; set; }
    public int BookingID { get; set; }
    public int HotelID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RoomType { get; set; }
}