using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelSearchController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HotelSearchController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Hotel>>> GetAvailableHotels()
    {
        // var list = _context.Database.SqlQuery<string>(
        //     $"SELECT H.Id, H.Name, CASE WHEN SR.Count < 20 THEN H.SingleCost ELSE NULL END AS SingleCost, CASE WHEN DR.Count < 20 THEN H.DoubleCost ELSE NULL END AS DoubleCost CASE WHEN"
        //     );
        
        DateTime inputStartDate = DateTime.Today;
        DateTime inputEndDate = DateTime.MaxValue;

        var list = await _context.Hotels.Select(hotel => new
            {
                HotelId = hotel.Id,
                HotelName = hotel.Name,
                
                // checks if number of single rooms booked between two dates given is less than 20
                // if it is, return single room cost, if not return null for single room value
                SingleRoomCost = _context.HotelBookings
                    .Count(booking => booking.HotelId == hotel.Id && booking.RoomType == "Single" && 
                                      booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
                    ? hotel.SingleCost : (decimal?) null,
                DoubleRoomCost = _context.HotelBookings
                    .Count(booking => booking.HotelId == hotel.Id && booking.RoomType == "Double" && 
                                      booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
                    ? hotel.DoubleCost : (decimal?) null,
                FamilyRoomCost = _context.HotelBookings
                    .Count(booking => booking.HotelId == hotel.Id && booking.RoomType == "Family" && 
                                      booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
                    ? hotel.FamilyCost : (decimal?) null
            })
            .ToListAsync();
        
        return Ok(list);
    }
}