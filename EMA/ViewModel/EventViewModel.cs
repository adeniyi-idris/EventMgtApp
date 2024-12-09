using EMA.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMA.ViewModel
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public FormatType FormatType { get; set; }
    }
}
