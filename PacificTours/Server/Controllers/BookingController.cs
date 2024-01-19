using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacificTours.Server.Services;
using PacificTours.Shared.Entities;
using PacificTours.Shared;

namespace PacificTours.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public BookingController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("AddTourBooking")]
    public async Task<ActionResult<Booking>> AddTourBooking(TourBookingInfoDto tourBookingInfo)
    {
        
        var tour = _context.Tours.Find(tourBookingInfo.Id);

        Booking newBooking = new Booking
        {
            Id = _context.Bookings.Count() + 1,
            UserId = _userManager.GetUserId(User),
            BookingDate = DateTime.Now,
            TotalCost = tour.Cost,
            Status = "Reserved"
        };

        _context.Bookings.Add(newBooking);
        
        var tourBooking = new TourBooking
        {
            Id = _context.TourBookings.Count() + 1,
            BookingId = newBooking.Id,
            TourId = tourBookingInfo.Id,
            StartDate = tourBookingInfo.StartDate,
            EndDate = tourBookingInfo.StartDate.AddDays(tour.Duration)
        };

        _context.TourBookings.Add(tourBooking);

        return Ok();
    }
    
    
    [HttpPost("AddHotelBooking")]
    public async Task<ActionResult<Booking>> AddHotelBooking(HotelBookingInfoDto hotelBookingInfo)
    {
        
        var tour = _context.Tours.Find(hotelBookingInfo.Id);

        Booking newBooking = new Booking
        {
            Id = _context.Bookings.Count() + 1,
            UserId = _userManager.GetUserId(User),
            BookingDate = DateTime.Now,
            TotalCost = tour.Cost,
            Status = "Reserved"
        };

        _context.Bookings.Add(newBooking);
        
        var tourBooking = new TourBooking
        {
            Id = _context.TourBookings.Count() + 1,
            BookingId = newBooking.Id,
            TourId = hotelBookingInfo.Id,
            StartDate = hotelBookingInfo.StartDate,
            EndDate = hotelBookingInfo.EndDate
        };

        _context.TourBookings.Add(tourBooking);

        return Ok();
    }
    
}