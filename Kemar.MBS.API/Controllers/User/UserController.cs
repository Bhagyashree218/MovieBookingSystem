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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var user = await _userService.LoginUserAsync(request);
            if (user == null) return Unauthorized("Invalid credentials");

            return Ok(user);
        }

        [HttpGet("profile/{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var profile = await _userService.GetUserProfileAsync(id);
            if (profile == null) return NotFound();

            return Ok(profile);
        }

    }
}
