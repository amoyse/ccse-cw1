namespace PacificTours.Server.Entities;

public class TourBooking
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public int TourId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual Booking Booking { get; set; }
    public virtual Tour Tour { get; set; }
}