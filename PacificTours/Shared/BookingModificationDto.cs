namespace PacificTours.Shared;

public class BookingModificationDto
{
    public int Id { get; set; }
    public DateTime? NewHotelStart { get; set; }
    public DateTime? NewTourStart { get; set; }
}