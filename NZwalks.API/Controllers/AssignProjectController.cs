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

            var wdm = new Assignmenent
            {
                ProjectId = addAssignProject.ProjectId,
                EmployeeId = addAssignProject.EmployeeId,
            };

            var res = await ap.AssignProject(wdm);

            var pn = await db.Projects.FindAsync(res.ProjectId);
            var ei = await db.Employees.FindAsync(res.EmployeeId);

            res.Project = pn;
            res.Employee = ei;


            return Ok(new { message = "Project assigned successfully", data = res });


            //   var res = await er.createEmployee(wdm);

            //    return Ok(map.Map<WalkDto>(res));


        }
    }
}
