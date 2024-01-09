namespace PacificTours.Server.Entities;

public class Hotel
{
    public int HotelID { get; set; }
    public string Name { get; set; }
    public int SingleCost { get; set; }
    public int DoubleCost { get; set; }
    public int FamilyCost { get; set; }
}