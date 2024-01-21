using Microsoft.AspNetCore.Authorization;
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
    
    
    [HttpGet("TourBookingInfo")]
    public async Task<ActionResult<List<TourBooking>>> GetTourBookingInfo()
    {
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        _booking = bookings.FirstOrDefault();
        
        if (_booking is null)
        {
            TourBookingInfoDto tourBookingInfoNull = null;
            return Ok(tourBookingInfoNull.ToJson());
        }
        
        var tourBookings = await _context.TourBookings.Where(tb => tb.BookingId == _booking.Id).ToListAsync();
        var tourBooking = tourBookings.FirstOrDefault();
        if (tourBooking is null)
        {
            return Ok(tourBooking.ToJson());
        }
        var tour = await _context.Tours.FindAsync(tourBooking.TourId);

        var tourBookingInfo = new TourBookingInfoDto
        {
            Id = tourBooking.Id,
            StartDate = tourBooking.StartDate,
            Name = tour.Name,
            Duration = tour.Duration,
            Cost = tour.Cost,

        };
        
        return Ok(tourBookingInfo);
    }

    [HttpGet("HotelBookingInfo")]
    public async Task<ActionResult<List<HotelBooking>>> GetHotelBookingInfo()
    {
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        _booking = bookings.FirstOrDefault();
        
        if (_booking is null)
        {
            HotelBookingInfoDto hotelBookingInfoNull = null;
            return Ok(hotelBookingInfoNull.ToJson());
        }
        
        var hotelBookings = await _context.HotelBookings.Where(hb => hb.BookingId == _booking.Id).ToListAsync();
        var hotelBooking = hotelBookings.FirstOrDefault();
        
        if (hotelBooking is null)
        {
            return Ok(hotelBooking.ToJson());
        }
        var hotel = await _context.Hotels.FindAsync(hotelBooking.HotelId);

        int roomCost = 0;
        if (hotelBooking.RoomType == "Single")
        {
            roomCost = hotel.SingleCost;
        }
        else if (hotelBooking.RoomType == "Double")
        {
            roomCost = hotel.DoubleCost;
        }
        else if (hotelBooking.RoomType == "Family")
        {
            roomCost = hotel.FamilyCost;
        }

        var hotelBookingInfo = new HotelBookingInfoDto()
        {
            Id = hotelBooking.Id,
            StartDate = hotelBooking.StartDate,
            Name = hotel.Name,
            EndDate = hotelBooking.EndDate,
            RoomCost = roomCost,
            RoomType = hotelBooking.RoomType
        };
        return Ok(hotelBookingInfo);
    }

    [HttpPost("AddTourBooking")]
    public async Task<ActionResult<Booking>> AddTourBooking(TourBookingInfoDto tourBookingInfo)
    {
        var tour = await _context.Tours.FindAsync(tourBookingInfo.Id);
        TourBooking tourBooking;

        // check if there is currently a booking in progress that hasn't been reserved
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        _booking = bookings.FirstOrDefault();
        var booking = _booking;
        
        if (booking is not null)
        {
            booking.TotalCost += tour.Cost;
                
            _context.Bookings.Update(booking);
                
            tourBooking = new TourBooking
            {
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
    
    
    [HttpPost("HotelBooking")]
    public async Task<ActionResult<Booking>> AddHotelBooking(HotelBookingInfoDto hotelBookingInfo)
    {
        HotelBooking hotelBooking;

        // check if there is currently a booking in progress that hasn't been reserved
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        _booking = bookings.FirstOrDefault();
        var booking = _booking;
        var totalRoomCost = (hotelBookingInfo.RoomCost * (hotelBookingInfo.EndDate - hotelBookingInfo.StartDate).Days);
        
        if (booking is not null)
        {
            booking.TotalCost += totalRoomCost;
            
            _context.Bookings.Update(booking);
                
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
            Console.WriteLine(_userManager.GetUserId(User));
            
            Booking newBooking = new Booking
            {
                UserId = _userManager.GetUserId(User),
                BookingDate = DateTime.Now,
                TotalCost = totalRoomCost,
                Status = "In Progress",
                HotelBooking = hotelBooking
            };
            _context.Bookings.Add(newBooking);
        }

        _context.HotelBookings.Add(hotelBooking);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("DeleteTour")]
    public async Task<ActionResult<Booking>> RemoveTourBooking(int id)
    {
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        var booking = bookings.FirstOrDefault();
        
        var tourBooking = await _context.TourBookings.FindAsync(id);
        if (tourBooking == null)
        {
            return NotFound("This tour booking does not exist!");
        }

        // Set the total cost back to the cost of just the current booked hotel (if hotel is booked)
        var hotelBookings = await _context.HotelBookings.Where(hb => hb.BookingId == booking.Id).ToListAsync();
        var hotelBooking = hotelBookings.FirstOrDefault();
        if (hotelBooking is not null)
        {
            var hotel = await _context.Hotels.FindAsync(hotelBooking.HotelId);
            if (hotelBooking.RoomType == "Single")
            {
                booking.TotalCost = hotel.SingleCost;
            }
            else if (hotelBooking.RoomType == "Double")
            {
                booking.TotalCost = hotel.DoubleCost;
            }
            else
            {
                booking.TotalCost = hotel.FamilyCost;
            }
            _context.Bookings.Update(booking);
        }
        else
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
        
        _context.TourBookings.Remove(tourBooking);
        await _context.SaveChangesAsync();
        return Ok();

    }
    
    [HttpDelete("DeleteHotel")]
    public async Task<ActionResult<Booking>> RemoveHotelBooking(int id)
    {
        var bookings = await _context.Bookings.Where(b => b.UserId == _userManager.GetUserId(User) && b.Status == "In Progress").ToListAsync();
        var booking = bookings.FirstOrDefault();
        
        var hotelBooking = await _context.HotelBookings.FindAsync(id);
        if (hotelBooking == null)
        {
            return NotFound("This hotel booking does not exist!");
        }

        // Set the total cost back to the cost of just the current booked tour (if tour is booked)
        var tourBookings = await _context.TourBookings.Where(tb => tb.BookingId == booking.Id).ToListAsync();
        var tourBooking = tourBookings.FirstOrDefault();
        if (tourBooking is not null)
        {
            var tour = await _context.Tours.FindAsync(tourBooking.TourId);
            booking.TotalCost = tour.Cost;
        }
        else
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
        
        _context.Bookings.Update(booking);
        _context.HotelBookings.Remove(hotelBooking);
        await _context.SaveChangesAsync();
        return Ok();
    }


    [HttpPost("ReserveBooking")]
    public async Task<ActionResult<Booking>> ReserveBooking(int id)
    {

        return Ok();
    }
    
    
}