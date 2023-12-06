using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiClient.Models
{

    public class EmployeeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        [Required]
        public string Gender { get; set; }

        [JsonPropertyName("mobile")]
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string Mobile { get; set; }

        [JsonPropertyName("address")]
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [JsonPropertyName("panNumber")]
        [Required]
        [RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN number.")]
        public string PanNumber { get; set; }

        [JsonPropertyName("adharNumber")]
        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar number must be 12 digits.")]
        public string AdharNumber { get; set; }


        [JsonPropertyName("email")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [JsonPropertyName("currentDate")]
        [Required]
        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
