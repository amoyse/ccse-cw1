namespace PacificTours.Shared.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SingleCost { get; set; }
    public int DoubleCost { get; set; }
    public int FamilyCost { get; set; }
    
    public IEnumerable<HotelBooking>? HotelBookings { get; set; }
}