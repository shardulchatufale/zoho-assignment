namespace NZwalks.API.Models.DTO
{
    public class AddProjectDto
    {
        public string ProjectName { get; set; }  // Name of the project
        public string Description { get; set; }  // Description of the project
        public DateTime StartDate { get; set; }  // Start date of the project
        public DateTime EndDate { get; set; }    // End date of the project
        public Guid ClientId { get; set; }       // Client ID to associate with the project
    }
}
