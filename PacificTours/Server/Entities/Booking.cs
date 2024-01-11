using System.Collections;

namespace PacificTours.Server.Entities;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int HotelBookingId { get; set; }
    public int TourBookingId { get; set; }
    public int PaymentId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalCost { get; set; }
    public string Status { get; set; }

    // public virtual ICollection<HotelBooking> HotelBookings { get; set; }
    // public virtual ICollection<TourBooking> TourBookings { get; set; }
}