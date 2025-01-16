using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class AddEmployeeDto
    {
        public string FirstName { get; set; }  // First Name
        public string LastName { get; set; }   // Last Name

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }      // Email Address

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; } // Phone Number
    }
}
