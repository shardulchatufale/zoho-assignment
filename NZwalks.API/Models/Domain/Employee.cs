using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }           // Primary Key
        public string FirstName { get; set; }  // First Name
        public string LastName { get; set; }   // Last Name

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }      // Email Address

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; } // Phone Number

   
    }
}
