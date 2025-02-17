﻿namespace NZwalks.API.Models.Domain
{
    public class LogTime
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; } 
        public Guid ProjectId { get; set; } 

        public double Hours { get; set; } 

        public string? Description { get; set; }

       
        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;
    }
}
