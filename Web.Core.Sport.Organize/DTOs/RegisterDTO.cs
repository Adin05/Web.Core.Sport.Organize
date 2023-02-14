using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web.Core.Sport.Organize.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [Required]
        [JsonPropertyName("email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        [Compare("Password")]
        [JsonPropertyName("repeatPassword")]
        public string RepeatPassword { get; set; }
    }

    public class RegisterResponseDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

    }
}
