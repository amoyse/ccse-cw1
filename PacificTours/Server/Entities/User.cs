using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PacificTours.Server.Entities;
using Microsoft.AspNetCore.Identity;

public class User: IdentityUser
{
   public int Id { get; set; }
   
   public string Name { get; set; } = "";

   public override string UserName { get; set; } = "";
   
   public string Password { get; set; } = "";
   
   public long PhoneNumber { get; set; } 
   public long PassportNumber { get; set; }

   public bool IsAdmin { get; set; } = false;
   
   public IEnumerable<Booking>? UserBookings { get; set; }
   
}