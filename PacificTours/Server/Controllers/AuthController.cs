using System.Collections;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using PacificTours.Shared.Entities;
using PacificTours.Server.Services;
using String = System.String;

namespace PacificTours.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet("GetAuthState")]
    public async Task<ActionResult<String>> GetAuthState()
    {
        if (_signInManager.IsSignedIn(User))
        {
            var userDict = new Dictionary<String, String>()
            {
                { "userId", _userManager.GetUserId(User) },
                { "userName", _userManager.GetUserName(User) }
            };
            return Ok(userDict);
        }
        return Ok("User is not signed in.");
    }

    [HttpGet("IsAuthorized")]
    public async Task<ActionResult<bool>> IsAuthorized(int id)
    {
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Id == id).ToListAsync();
        var booking = bookings.FirstOrDefault();

        if (booking is null)
        {
            return Ok(false.ToJson());
        }
        return Ok(true.ToJson());
    }

}