using System;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class AddLogtimeDTO
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        [RegularExpression(@"^(?!00000000-0000-0000-0000-000000000000$).+", ErrorMessage = "Employee ID cannot be empty or whitespace.")]
        public Guid? EmployeeId { get; set; } // Employee ID

        [Required(ErrorMessage = "Project ID is required.")]
        [RegularExpression(@"^(?!00000000-0000-0000-0000-000000000000$).+", ErrorMessage = "Project ID cannot be empty or whitespace.")]
        public Guid? ProjectId { get; set; } // Project ID

        [Required(ErrorMessage = "Hours are required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Hours must be greater than zero.")]
        public double Hours { get; set; } // Logged hours

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; } // Optional description
    }
}
