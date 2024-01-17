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

    [HttpGet]
    public async Task<ActionResult<String>> GetAuthState()
    {
        if (_signInManager.IsSignedIn(User))
        {
            // var json = JsonSerializer.Serialize(User.Claims, new JsonSerializerOptions()
            // {
            //     ReferenceHandler = ReferenceHandler.IgnoreCycles
            // });
            // return Ok(json);

            var userDict = new Dictionary<String, String>()
            {
                { "userId", _userManager.GetUserId(User) },
                { "userName", _userManager.GetUserName(User) }
            };
            

            return Ok(userDict);

        }
        return Ok("User is not signed in.");
    }

}