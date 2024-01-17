namespace PacificTours.Shared.Entities;

public class TourBooking
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public int TourId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Tour Tour { get; set; }
    public Booking? Booking { get; set; }
}