using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;
using PacificTours.Shared;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public PaymentsController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    [HttpPost("AddPayment")]
    public async Task AddPayment(int id)
    {

    }
}