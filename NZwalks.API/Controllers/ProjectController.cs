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

            var pdm = map.Map<Project>(adpdto);

            // Check if ClientId exists
            var checkCID = await db.Clients.FindAsync(adpdto.ClientId);
            if (checkCID == null) // Fixed comparison operator
            {
                return NotFound(new { Message = "Client ID not found in the database." });
            }

            var res = await pl.CreateProject(pdm);

            // Set the Client navigation property
            res.Client = checkCID;

            return Ok(new { message = "Project created successfully", data = res });

        }
    }
}
