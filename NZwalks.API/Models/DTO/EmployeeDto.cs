using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }          
        public string FirstName { get; set; }  
        public string LastName { get; set; }   

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }      

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; } 

    }
}
