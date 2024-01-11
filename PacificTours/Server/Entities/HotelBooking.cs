namespace PacificTours.Server.Entities;

public class HotelBooking
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public int HotelId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RoomType { get; set; }
}