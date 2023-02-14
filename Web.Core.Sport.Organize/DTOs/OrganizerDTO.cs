using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Web.Core.Sport.Organize.Models;

namespace Web.Core.Sport.Organize.DTOs
{
    public class OrganizerDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("organizerName")]
        [Required]
        [Display(Name = "Organizer Name")]
        public string OrganizerName { get; set; }
        [JsonPropertyName("imageLocation")]
        [Required]
        [Display(Name = "Image Location")]
        public string ImageLocation { get; set; }
    }
    public class ResponseOrganizerDTO
    {
        [JsonPropertyName("data")]
        public List<OrganizerDTO> Data { get; set; }
        [JsonPropertyName("meta")]
        public MetaModel Meta { get; set; }
    }
}
