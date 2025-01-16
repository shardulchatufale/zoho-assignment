using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.DTO;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IclientRepository wl;
        private readonly IMapper mapper;

        public ClientController(IMapper mapper, IclientRepository wl)
        {
            this.wl = wl;
            this.mapper = mapper;
        }
        /*
        [HttpPost]
         [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateClient([FromBody] AddClientDto addClientDto)
        {

            var cdm = mapper.Map<Client>(addClientDto);

            var res = await wl.CreateClient(cdm);

            return Ok(res);


        }
        */
        [HttpPost]
         [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateClient([FromBody] AddClientDto addClientDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            var cdm = mapper.Map<Client>(addClientDto);

            var res = await wl.CreateClient(cdm);

            return Ok(new { message = "Client added successfully ", data = res });
           

        }
    }
}
