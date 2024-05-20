using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToursController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ToursController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    // Send back a list of all tours, and their attributes
    [HttpGet]
    public async Task<ActionResult<List<Tour>>> GetAllTours()
    {
        var list = await _context.Tours.ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Tour>>> GetTourDetails(int id)
    {
        var tourDetails = await _context.Tours.FindAsync(id);
        if (tourDetails == null)
        {
            return NotFound("This tour does not exist!");
        }
        return Ok(tourDetails);
    }
    
    [HttpGet("GetDates")]
    public async Task<ActionResult<List<Tour>>> GetAvailableTours(DateTime startDate)
    {
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
