using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.Domain
{
    public class Assignmenent
    {
        [Key] 
        public Guid Id { get; set; } 

        [Required(ErrorMessage = "Employee ID is required.")] 
        [ForeignKey("Employee")] 
        public Guid EmployeeId { get; set; } 

        [Required(ErrorMessage = "Project ID is required.")] 
        [ForeignKey("Project")] 
        public Guid ProjectId { get; set; } 

       
        [Required(ErrorMessage = "Employee navigation property cannot be null.")] 
        public Employee Employee { get; set; } = null!; 

        [Required(ErrorMessage = "Project navigation property cannot be null.")] 
        public Project Project { get; set; } = null!;
    }
}
