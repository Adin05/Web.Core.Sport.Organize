using System.Text.Json.Serialization;

namespace Web.Core.Sport.Organize.DTOs
{
    public class UserDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
