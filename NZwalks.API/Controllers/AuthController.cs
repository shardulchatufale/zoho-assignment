using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.DTO;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ItokenRepository tokenRepository;
        
        public AuthController(UserManager<IdentityUser> userManager,ItokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create IdentityUser
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email
            };

            // Attempt to create user
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if (!identityResult.Succeeded)
            {
                // Return detailed errors
                return BadRequest(new { Errors = identityResult.Errors.Select(e => e.Description) });
            }

            // Check and add roles if provided
            if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
            {
                identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                if (!identityResult.Succeeded)
                {
                    // Return detailed errors
                    return BadRequest(new { Errors = identityResult.Errors.Select(e => e.Description) });
                }
            }

            return Ok("User is registered! Please login.");
        }


        //-------------------------------------------------------------------


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var User = await userManager.FindByEmailAsync(loginRequestDTO.UserNmae);
           
            if (User != null)
            {
           var CheckPassReasult=    await userManager.CheckPasswordAsync(User, loginRequestDTO.Password);

                if (CheckPassReasult)
                {
                  var roles=  await userManager.GetRolesAsync(User);

                    if (roles != null)
                    {
                        var JwtToken = tokenRepository.CreateJwtToken(User, roles.ToList());
                             var resp=new LoginResponceDTO
                             {
                                  JWTToken = JwtToken 
                             };
                             return Ok(resp);
                    } 
                }

            }
            return BadRequest("Username or password is wrong");

        }
    }
}
