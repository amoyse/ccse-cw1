using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PacificTours.Server.Entities;
using Microsoft.AspNetCore.Identity;

public class User: IdentityUser
{
   public int Id { get; set; } 
   public string Name { get; set; } 
   public string UserName { get; set; } 
   public string Password { get; set; } 
   public int PhoneNumber { get; set; } 
   public int PassportNumber { get; set; } 
   
   
}