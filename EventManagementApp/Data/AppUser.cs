using EventManagementApp.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Data
{
    public class AppUser: IdentityUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public List<Registration> Registrations { get; set; }
    }
}
