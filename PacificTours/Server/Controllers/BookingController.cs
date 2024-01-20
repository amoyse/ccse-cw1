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

    public BookingController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("AddTourBooking")]
    public async Task<ActionResult<Booking>> AddTourBooking(TourBookingInfoDto tourBookingInfo)
    {
        var tour = await _context.Tours.FindAsync(tourBookingInfo.Id);
        TourBooking tourBooking;

        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        var booking = bookings.FirstOrDefault();
        
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
        
        var hotel = await _context.Hotels.FindAsync(hotelBookingInfo.Id);

        HotelBooking hotelBooking;

        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        var booking = bookings.FirstOrDefault();
        
        if (booking is not null)
        {
            booking.TotalCost += hotelBookingInfo.RoomCost;
                
            hotelBooking = new HotelBooking
            {
                Id = _context.TourBookings.Count() + 1,
                BookingId = booking.Id,
                HotelId = hotelBookingInfo.Id,
                StartDate = hotelBookingInfo.StartDate,
                EndDate = hotelBookingInfo.EndDate
            };
        }
        else
        {
            hotelBooking = new HotelBooking
            {
                HotelId = hotelBookingInfo.Id,
                StartDate = hotelBookingInfo.StartDate,
                EndDate = hotelBookingInfo.EndDate
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