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
    public class CreateEmployeeController : ControllerBase
    {
        private readonly IMapper map;
        private readonly IEmplyeeRepository er;
        public CreateEmployeeController(IMapper map, IEmplyeeRepository er)
        {
            this.map = map;
            this.er = er;

        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeDto frmdto)
        {
          
            var wdm = map.Map<Employee>(frmdto);

            var res = await er.createEmployee(wdm);



            return Ok(new { message = "Employee added successfully", data = res });


        }
    }
}
