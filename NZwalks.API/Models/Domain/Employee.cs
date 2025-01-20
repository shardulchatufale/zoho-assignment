using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.Domain
{
    public class Employee
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
