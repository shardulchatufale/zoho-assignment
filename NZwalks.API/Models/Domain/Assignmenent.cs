namespace NZwalks.API.Models.Domain
{
    public class Assignmenent
    {
        public Guid Id { get; set; } // Primary Key

        public Guid EmployeeId { get; set; } // Foreign Key for Employee
        public Guid ProjectId { get; set; }  // Foreign Key for Project

        // Navigation Properties
        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;
    }
}
