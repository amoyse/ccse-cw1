using Microsoft.AspNetCore.Identity;
using PacificTours.Server.Entities;

namespace PacificTours.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


public class ApplicationDbContext: IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var manager = new IdentityRole("manager");
        manager.NormalizedName = "manager";
        
        var client = new IdentityRole("client");
        client.NormalizedName = "client";

        builder.Entity<IdentityRole>().HasData(manager, client);
        
        // builder.Entity<Users>().HasKey

        builder.Entity<Hotel>().HasData(new Hotel
        {
            Id = 1,
            Name = "Hilton London Hotel",
            SingleCost = 365,
            DoubleCost = 775,
            FamilyCost = 950
        });
        builder.Entity<Hotel>().HasData(new Hotel
        {
            Id = 2,
            Name = "London Marriott Hotel",
            SingleCost = 300,
            DoubleCost = 500,
            FamilyCost = 900
        });
        builder.Entity<Hotel>().HasData(new Hotel
        {
            Id = 3,
            Name = "Travelodge Brighton Seafront",
            SingleCost = 80,
            DoubleCost = 120,
            FamilyCost = 150
        });
        builder.Entity<Hotel>().HasData(new Hotel
        {
            Id = 4,
            Name = "Kings Hotel Brighton",
            SingleCost = 180,
            DoubleCost = 400,
            FamilyCost = 520
        });
        builder.Entity<Hotel>().HasData(new Hotel
        {
            Id = 5,
            Name = "Leonardo Hotel Brighton",
            SingleCost = 180,
            DoubleCost = 400,
            FamilyCost = 520
        });
        builder.Entity<Hotel>().HasData(new Hotel
        {
            Id = 6,
            Name = "Nevis Bank Inn, Fort William",
            SingleCost = 90,
            DoubleCost = 100,
            FamilyCost = 155
        });

        builder.Entity<Tour>().HasData(new Tour
        {
            Id = 1,
            Name = "Real Britain",
            Duration = 6,
            Cost = 1200,
            Spaces = 30
        });
        builder.Entity<Tour>().HasData(new Tour
        {
            Id = 2,
            Name = "Britain and Ireland Explorer",
            Duration = 16,
            Cost = 2000,
            Spaces = 40
        });
        builder.Entity<Tour>().HasData(new Tour
        {
            Id = 3,
            Name = "Best of Britain",
            Duration = 12,
            Cost = 2900,
            Spaces = 30
        });

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Tour> Tour { get; set; }
    public DbSet<HotelBooking> HotelBookings { get; set; }
    public DbSet<TourBooking> TourBookings { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Payment> Payments { get; set; }
}