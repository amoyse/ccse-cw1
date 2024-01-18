using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllToursController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AllToursController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    // Send back a list of all hotels, and their attributes
    [HttpGet]
    public async Task<ActionResult<List<Tour>>> GetAllHotels()
    {
        var list = await _context.Hotels.ToListAsync();
        return Ok(list);
    }
    
}
