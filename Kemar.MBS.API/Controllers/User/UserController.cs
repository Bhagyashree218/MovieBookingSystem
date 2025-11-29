using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.User.Request;
using Microsoft.AspNetCore.Mvc;


namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var result =  await _userService.RegisterUserAsync(request);

            if (result == null)
                return BadRequest("Email already exists.");

            return Ok(new { result });
        }

    }
}
