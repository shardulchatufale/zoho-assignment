using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.DTO;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTimeController : ControllerBase
    {
        private readonly NZWalksDBContext dbd;
        private readonly IMapper map;
        private readonly ILogTime lt;
        public LogTimeController(IMapper map, ILogTime lt, NZWalksDBContext dbd)
        {
            this.map = map;
            this.lt = lt;
            this.dbd = dbd;

        }

        [HttpPost]
        public async Task<IActionResult> CreateLogTime([FromBody] AddLogtimeDTO frmdto)
        {
            
            var logTime = map.Map<LogTime>(frmdto);

            
            var assignmentExists = await dbd.Assignmenents
                .AnyAsync(a => a.EmployeeId == logTime.EmployeeId && a.ProjectId == logTime.ProjectId);

            if (!assignmentExists)
            {
               
                return BadRequest("The specified project is not assigned to the given employee.");
            }





            var result = await lt.AddLogTime(logTime);
            var pn = await dbd.Projects.FindAsync(result.ProjectId);
            var ei = await dbd.Employees.FindAsync(result.EmployeeId);

            result.Project = pn;
            result.Employee = ei;

            return Ok(new { message = "LogTime added successfully", data = result });
        }
    }
}
//https://github.com/shardulchatufale/dotNet_Assignment_1.git