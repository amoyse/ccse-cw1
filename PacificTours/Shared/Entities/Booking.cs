using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacificTours.Shared.Entities;

public class Booking
{
    public int Id { get; set; }
    public string UserId { get; set; }
    
    public DateTime BookingDate { get; set; }
    public int TotalCost { get; set; }
    public string Status { get; set; }

    public HotelBooking? HotelBooking { get; set; }
    public TourBooking? TourBooking { get; set; }
    public IEnumerable<Payment>? BookingPayments { get; set; }
    public User? User { get; set; }
}