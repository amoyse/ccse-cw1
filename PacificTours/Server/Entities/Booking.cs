using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacificTours.Server.Entities;

public class Booking
{
    public int Id { get; set; }
    
    [ForeignKey("UserId")]
    public string UserId { get; set; }
    
    [ForeignKey("HotelBookingId")]
    public int? HotelBookingId { get; set; }
    
    [ForeignKey("TourBookingId")]
    public int? TourBookingId { get; set; }
    
    [ForeignKey("PaymentId")]
    public int? PaymentId { get; set; }
    
    public DateTime BookingDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalCost { get; set; }
    public string Status { get; set; }

    public virtual HotelBooking HotelBooking { get; set; }
    public virtual TourBooking TourBooking { get; set; }
    public virtual Payment Payment { get; set; }
    public virtual User User { get; set; }
    // public virtual ICollection<HotelBooking> HotelBookings { get; set; }
    // public virtual ICollection<TourBooking> TourBookings { get; set; }
}