using System;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class AddProjectDto
    {
        [Required(ErrorMessage = "Project name is required.")]
        public string ProjectName { get; set; } = null!; 

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!; 

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; } 

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; } 

        [Required(ErrorMessage = "Client ID is required.")]
        [CustomValidation(typeof(AddProjectDto), nameof(ValidateClientId))]
        public Guid ClientId { get; set; } 

       
        public static ValidationResult? ValidateClientId(Guid clientId, ValidationContext context)
        {
            if (clientId == Guid.Empty)
            {
                return new ValidationResult("Client ID is invalid or missing.", new[] { nameof(ClientId) });
            }
            return ValidationResult.Success;
        }
    }
}
