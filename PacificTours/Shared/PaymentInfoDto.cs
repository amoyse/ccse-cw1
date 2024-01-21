namespace PacificTours.Shared;

public class PaymentInfoDto
{
    public int? BookingId { get; set; }
    public int Amount { get; set; }
    public DateTime? DatePaid { get; set; }
    public string? Status { get; set; }

}