namespace PacificTours.Shared;

public class TourBookingInfoDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public string? Name { get; set; }
    public int? Duration { get; set; }
    public int? Cost { get; set; }
}