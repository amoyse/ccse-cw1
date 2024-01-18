using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TourSearchController : ControllerBase
{
    
    private readonly ApplicationDbContext _context;

    public TourSearchController(ApplicationDbContext context)
    {
        _context = context;
    }

    // [HttpGet("GetDates")]
    // public async Task<ActionResult<List<Hotel>>> GetAvailableHotels(DateTime startDate)
    // {
    //     DateTime inputStartDate = startDate;
    //     
    //     // var list = await _context.Tours.Select(tour => new
    //     //     {
    //     //         Id = tour.Id,
    //     //         Name = tour.Name,
    //     //         
    //     //         // checks if number of single rooms booked between two dates given is less than 20
    //     //         // if it is, return single room cost, if not return null for single room value
    //     //         SingleCost = _context.HotelBookings
    //     //             .Count(booking => booking.HotelId == tour.Id && booking.RoomType == "Single" && 
    //     //                               booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
    //     //             ? tour.SingleCost : (int?) null,
    //     //         DoubleCost = _context.HotelBookings
    //     //             .Count(booking => booking.HotelId == tour.Id && booking.RoomType == "Double" && 
    //     //                               booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
    //     //             ? tour.DoubleCost : (int?) null,
    //     //         FamilyCost = _context.HotelBookings
    //     //             .Count(booking => booking.HotelId == tour.Id && booking.RoomType == "Family" && 
    //     //                               booking.StartDate <= inputEndDate && booking.EndDate >= inputStartDate) < 20 
    //     //             ? tour.FamilyCost : (int?) null
    //     //     })
    //     //     .ToListAsync();
    //     
    //     return Ok(list);
    //     
    // }

}