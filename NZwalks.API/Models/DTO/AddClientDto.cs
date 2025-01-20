using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class AddClientDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(10, ErrorMessage = "Name must be a maximum of 10 alphabet characters.")]
        public string Name { get; set; } = null!; 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!; 

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; } = null!; 

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = null!; 
    }
}
