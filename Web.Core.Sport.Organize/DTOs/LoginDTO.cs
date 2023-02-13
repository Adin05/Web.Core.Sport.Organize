using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web.Core.Sport.Organize.DTOs
{
    public class LoginDTO
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class LoginResponseDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }

    }
}
