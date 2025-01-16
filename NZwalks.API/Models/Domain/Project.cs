namespace NZwalks.API.Models.Domain
{
    public class Project
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
