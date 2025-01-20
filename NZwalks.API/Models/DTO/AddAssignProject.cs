using System;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO
{
    public class AddAssignProject
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        [RegularExpression(@"^(?!00000000-0000-0000-0000-000000000000$).+", ErrorMessage = "Employee ID cannot be empty, null, or whitespace.")]
        public Guid? EmployeeId { get; set; } // Employee ID

        [Required(ErrorMessage = "Project ID is required.")]
        [RegularExpression(@"^(?!00000000-0000-0000-0000-000000000000$).+", ErrorMessage = "Project ID cannot be empty, null, or whitespace.")]
        public Guid? ProjectId { get; set; } // Project ID
    }
}

