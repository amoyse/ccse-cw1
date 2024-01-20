namespace PacificTours.Shared;

public class HotelBookingInfoDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RoomCost { get; set; }
    public string RoomType { get; set; }
    public string Name { get; set; }
}