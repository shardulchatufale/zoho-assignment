using NZwalks.API.Models.Domain;

namespace NZwalks.API.Models.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; } 
        public string ProjectName { get; set; } 
        public string Description { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }
    }
}
