using System.ComponentModel.DataAnnotations.Schema;
using EMA.Enums;

namespace EMA.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public FormatType FormatType { get; set; }
        public IndustryType IndustryType { get; set; }
        public DateTime RegistyrationDate { get; set; }
        public AppUser? AppUser { get; set; }

        public Event Event { get; set; }
    }
}
