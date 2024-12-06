using EMA.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMA.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public string Location { get; set; }
        public FormatType FormatType { get; set; }
        public AppUser? AppUser { get; set; }
        public List<Registration> Registrations { get; set; }
    }
}
