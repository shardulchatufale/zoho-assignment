using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class AddEmployeeDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } 

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }  

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }     

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; } 
    }
}
