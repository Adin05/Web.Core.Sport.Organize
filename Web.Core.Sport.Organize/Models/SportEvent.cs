using System;

namespace Web.Core.Sport.Organize.Models
{
    public class SportEvent
    {
        public int ID { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public int OrganizerId { get; set; }
    }
}
