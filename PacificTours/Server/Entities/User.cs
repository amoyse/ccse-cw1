namespace PacificTours.Server.Entities;
using Microsoft.AspNetCore.Identity;

public class User: IdentityUser
{
   public int UserID { get; set; } 
   public string Name { get; set; } 
   public string Username { get; set; } 
   public string Password { get; set; } 
   public int PhoneNumber { get; set; } 
   public int PassportNumber { get; set; } 
   
   
}