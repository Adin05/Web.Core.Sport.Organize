using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Web.Core.Sport.Organize.Models;

namespace Web.Core.Sport.Organize.DTOs
{
    public class SportEventDTO
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        [JsonPropertyName("eventDate")]
        public DateTime EventDate { get; set; }
        [Required]
        [Display(Name = "Event Type")]
        [JsonPropertyName("eventType")]
        public string EventType { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        [JsonPropertyName("eventName")]
        public string EventName { get; set; }
        [Required]
        [Display(Name = "Organizer")]
        public int OrganizerId { get; set; }
        [JsonPropertyName("organizer")]
        public OrganizerDTO Organizer { get; set; }
    }
    public class ResponseSportEventDTO
    {
        [JsonPropertyName("data")]
        public List<SportEventDTO> Data { get; set; }
        [JsonPropertyName("meta")]
        public MetaModel Meta { get; set; }
    }
}
