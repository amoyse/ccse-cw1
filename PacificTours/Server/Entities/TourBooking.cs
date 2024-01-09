namespace PacificTours.Server.Entities;

public class TourBooking
{
    public int TourBookingID { get; set; }
    public int BookingID { get; set; }
    public int TourID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}