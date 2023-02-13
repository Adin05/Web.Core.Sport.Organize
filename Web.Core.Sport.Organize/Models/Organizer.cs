using Microsoft.AspNetCore.Identity;

namespace Web.Core.Sport.Organize.Models
{
    public class Organizer
    {
        public int ID { get; set; }
        public string OrganizerName { get; set; }
        public string ImageLocation { get; set; }
    }
}
