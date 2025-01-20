using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.DTO;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Writer")]
    [ApiController]
    public class AssignProjectController : ControllerBase
    {
        private readonly IMapper map;
        private readonly IAssignProject ap;
        private readonly NZWalksDBContext db;
        public AssignProjectController(IMapper map, IAssignProject ap,NZWalksDBContext db)
        {
            this.map = map;
            this.ap = ap;
            this.db = db;

        }
        [HttpPost]
        public async Task<IActionResult> asignProject([FromBody] AddAssignProject addAssignProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }


            var checkPId = await db.Projects.FindAsync(addAssignProject.ProjectId);
            if (checkPId == null)
            {
                return NotFound(new { Message = "Project ID not found in the database." });
            }

            var checkEid = await db.Employees.FindAsync(addAssignProject.EmployeeId);
            if (checkEid == null)
            {
                return NotFound(new { Message = "Employee ID not found in the database." });
            }
            

            var wdm = map.Map<Assignmenent>(addAssignProject);
          
            var res = await ap.AssignProject(wdm);

            var pn = await db.Projects.FindAsync(res.ProjectId);
            var ei = await db.Employees.FindAsync(res.EmployeeId);

            res.Project = pn;
            res.Employee = ei;


            return Ok(new { message = "Project assigned successfully", data = res });

        }
    }
}
