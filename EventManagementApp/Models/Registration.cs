using System.ComponentModel.DataAnnotations.Schema;
using EventManagementApp.Data;
using EventManagementApp.Enums;

namespace EventManagementApp.Models
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
    }
}
