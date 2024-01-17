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
    
    [HttpGet("GetDates")]
    public async Task<ActionResult<List<Hotel>>> GetAvailableHotels(DateTime startDate, DateTime endDate)
    {
        DateTime inputStartDate = startDate;
        DateTime inputEndDate = endDate;
        
        var list = await _context.Hotels.Select(hotel => new
            {
                Id = hotel.Id,
                Name = hotel.Name,
                
                // checks if number of single rooms booked between two dates given is less than 20
                // if it is, return single room cost, if not return null for single room value
                SingleCost = _context.HotelBookings
                    .Count(booking => booking.HotelId == hotel.Id && booking.RoomType == "Single" && 
                                      booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
                    ? hotel.SingleCost : (int?) null,
                DoubleCost = _context.HotelBookings
                    .Count(booking => booking.HotelId == hotel.Id && booking.RoomType == "Double" && 
                                      booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
                    ? hotel.DoubleCost : (int?) null,
                FamilyCost = _context.HotelBookings
                    .Count(booking => booking.HotelId == hotel.Id && booking.RoomType == "Family" && 
                                      booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
                    ? hotel.FamilyCost : (int?) null
            })
            .ToListAsync();
        
        return Ok(list);
    }
}