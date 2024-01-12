using System.Security.Principal;

namespace PacificTours.Server.Entities;

public class Tour
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public int Cost { get; set; }
    public int Spaces { get; set; }
    public DateTime StartDate { get; set; }
    
    public IEnumerable<TourBooking>? TourBookings { get; set; }
}