using EMA.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EMA.Data
{
    public class AppUser: IdentityUser
    {
        public List<Registration> Registrations { get; set; }
    }
}
