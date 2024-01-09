namespace PacificTours.Server.Entities;

public class Payment
{
    public int PaymentID { get; set; }
    public int BookingID { get; set; }
    public int Amount { get; set; }
    public DateTime DatePaid { get; set; }
    public string Status { get; set; }
}