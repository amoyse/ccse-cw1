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

    [HttpGet("GetDates")]
    public async Task<ActionResult<List<Tour>>> GetAvailableTours(DateTime startDate)
    {
        Console.WriteLine("made it here");
        DateTime inputStartDate = startDate;
        
        var list = await _context.Tours.Select(tour => new
            {
                Id = tour.Id,
                Name = tour.Name,
                Duration = tour.Duration,
                
                // selects cost of a tour IF there is at least one space available
                Cost = _context.TourBookings
                    .Count(booking => booking.TourId == tour.Id && 
                                       booking.StartDate == inputStartDate) < tour.Spaces 
                    ? tour.Cost : (int?) null,
            })
            .ToListAsync();
        
        return Ok(list);
        
    }

}