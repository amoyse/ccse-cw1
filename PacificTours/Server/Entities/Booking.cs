namespace PacificTours.Server.Entities;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalCost { get; set; }
    public string Status { get; set; }
}