namespace PacificTours.Server.Entities;

public class Booking
{
    public int BookingID { get; set; }
    public int UserID { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalCost { get; set; }
    public string Status { get; set; }
}