using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web.Core.Sport.Organize.DTOs
{
    public class ChangePasswordDTO
    {

        [Required]
        [JsonPropertyName("oldPassword")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [JsonPropertyName("newPassword")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        [Compare("NewPassword")]
        [JsonPropertyName("repeatPassword")]
        public string RepeatPassword { get; set; }
    }
}
