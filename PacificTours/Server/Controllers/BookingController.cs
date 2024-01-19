using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;
using PacificTours.Shared;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> AddBooking(BookingInfoDto bookingInfo)
    {
        
        // Check if booking a tour or hotel
        if (bookingInfo.StartDate == bookingInfo.EndDate)
        {
            var tour = _context.Tours.Find(bookingInfo.Id);
            

        }
        else
        {
            
        }
        return Ok();
    }
    
}