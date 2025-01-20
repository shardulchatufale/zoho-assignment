using System;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }     

        [MaxLength(10, ErrorMessage = "Name must be a maximum of 10 alphabet characters.")]
        public string Name { get; set; } = null!; 

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }       

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? PhoneNumber { get; set; } 

        public string? Address { get; set; }    
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
    }
}
