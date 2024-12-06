using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMA.Models
{
    public class AppUser: IdentityUser
    {
        public string? NickName { get; set; }
        [NotMapped]
        public string? RoleId { get; set; }
        [NotMapped]
        public string? Role { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? RoleList { get; set; }
        public List<Registration>? Registrations { get; set; }
        public List<Event> Events { get; set; }
    }
}
