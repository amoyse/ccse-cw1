using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    private readonly UserManager<User> _userManager;
    private Booking? _booking;

    public BookingController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async void SetBookingInProgress()
    {
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        _booking = bookings.FirstOrDefault();
    }
    
    [HttpGet("TourBookingInfo")]
    public async Task<ActionResult<List<Booking>>> GetTourBookingInfo()
    {
        SetBookingInProgress();
        var tourBookings = await _context.TourBookings.Where(tb => tb.BookingId == _booking.Id).ToListAsync();
        return Ok(tourBookings);
    }

    [HttpGet("HotelBookingInfo")]
    public async Task<ActionResult<List<Booking>>> GetHotelBookingInfo()
    {
        SetBookingInProgress();
        var hotelBookings = await _context.HotelBookings.Where(hb => hb.BookingId == _booking.Id).ToListAsync();
        return Ok(hotelBookings);
    }

    [HttpPost("AddTourBooking")]
    public async Task<ActionResult<Booking>> AddTourBooking(TourBookingInfoDto tourBookingInfo)
    {
        var tour = await _context.Tours.FindAsync(tourBookingInfo.Id);
        TourBooking tourBooking;

        // check if there is currently a booking in progress that hasn't been reserved
        SetBookingInProgress();
        var booking = _booking;
        
        if (booking is not null)
        {
            booking.TotalCost += tour.Cost;
                
            _context.Bookings.Update(booking);
                
            tourBooking = new TourBooking
            {
                Id = _context.TourBookings.Count() + 1,
                BookingId = booking.Id,
                TourId = tourBookingInfo.Id,
                StartDate = tourBookingInfo.StartDate,
                EndDate = tourBookingInfo.StartDate.AddDays(tour.Duration)
            };
        }
        else
        {
            tourBooking = new TourBooking
            {
                TourId = tourBookingInfo.Id,
                StartDate = tourBookingInfo.StartDate,
                EndDate = tourBookingInfo.StartDate.AddDays(tour.Duration)
            };
            
            Booking newBooking = new Booking
            {
                UserId = _userManager.GetUserId(User),
                BookingDate = DateTime.Now,
                TotalCost = tour.Cost,
                Status = "In Progress",
                TourBooking = tourBooking
            };
            
            _context.Bookings.Add(newBooking);
        }

        _context.TourBookings.Add(tourBooking);
        await _context.SaveChangesAsync();

        return Ok();
    }
    
    
    [HttpPost("AddHotelBooking")]
    public async Task<ActionResult<Booking>> AddHotelBooking(HotelBookingInfoDto hotelBookingInfo)
    {
        
        HotelBooking hotelBooking;

        // check if there is currently a booking in progress that hasn't been reserved
        SetBookingInProgress();
        var booking = _booking;
        
        if (booking is not null)
        {
            booking.TotalCost += hotelBookingInfo.RoomCost;
                
            hotelBooking = new HotelBooking
            {
                BookingId = booking.Id,
                HotelId = hotelBookingInfo.Id,
                StartDate = hotelBookingInfo.StartDate,
                EndDate = hotelBookingInfo.EndDate,
                RoomType = hotelBookingInfo.RoomType
            };
        }
        else
        {
            hotelBooking = new HotelBooking
            {
                HotelId = hotelBookingInfo.Id,
                StartDate = hotelBookingInfo.StartDate,
                EndDate = hotelBookingInfo.EndDate,
                RoomType = hotelBookingInfo.RoomType
            };
            
            Booking newBooking = new Booking
            {
                UserId = _userManager.GetUserId(User),
                BookingDate = DateTime.Now,
                TotalCost = hotelBookingInfo.RoomCost,
                Status = "In Progress",
                HotelBooking = hotelBooking
            };
            _context.Bookings.Add(newBooking);
        }

        _context.HotelBookings.Add(hotelBooking);
        await _context.SaveChangesAsync();

        return Ok();
    }
    
}