namespace NZwalks.API.Models.Domain
{
    public class LogTime
    {
        public Guid Id { get; set; } // Primary Key

        public Guid EmployeeId { get; set; } // Foreign Key for Employee
        public Guid ProjectId { get; set; }  // Foreign Key for Project

        public double Hours { get; set; } // Hours logged

        public string? Description { get; set; }

        // Navigation Properties
        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;
    }
}
