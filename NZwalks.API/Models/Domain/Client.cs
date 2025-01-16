using System;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }         // Primary Key

        [MaxLength(10, ErrorMessage = "Name must be a maximum of 10 alphabet characters.")]
        public string Name { get; set; } = null!; // Client Name

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }       // Email Address

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? PhoneNumber { get; set; } // Phone Number

        public string? Address { get; set; }     // Address
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Created Timestamp
    }
}
