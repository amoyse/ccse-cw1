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
        var list = await _context.Hotels.ToListAsync();
        return Ok(list);
    }
}