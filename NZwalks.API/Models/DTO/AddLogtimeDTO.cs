namespace NZwalks.API.Models.DTO
{
    public class AddLogtimeDTO
    {
        public Guid EmployeeId { get; set; } // Foreign Key for Employee
        public Guid ProjectId { get; set; }  // Foreign Key for Project

        public double Hours { get; set; } // Hours logged

        public string? Description { get; set; }
    }
}
