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
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMapper map;
        private readonly IProjecReposiotory pl;
        private readonly NZWalksDBContext db;
        public ProjectController(IMapper map, IProjecReposiotory pl,NZWalksDBContext db)
        {
            this.map = map;
            this.pl = pl;
            this.db= db;

        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateProject([FromBody] AddProjectDto adpdto)
        {

            var projectwdm = new Project
            {
                ProjectName = adpdto.ProjectName,
                Description = adpdto.Description,
                StartDate = adpdto.StartDate,
                EndDate = adpdto.EndDate,
                ClientId = adpdto.ClientId
            };
            var res = await pl.CreateProject(projectwdm);
            //map.Map<AddProjectDto>(res);

            var client = await db.Clients.FindAsync(res.ClientId);
            res.Client = client;
            return Ok(new { message = "Project created successfully", data = res });

        }
    }
}
