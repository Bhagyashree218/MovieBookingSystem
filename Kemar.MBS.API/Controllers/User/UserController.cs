using Kemar.MBS.API.Core.Helper;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
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
            var result = await _userService.RegisterUserAsync(request);
            return CommonHelper.ReturnActionResultByStatus(result, this);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var loginResponse = await _userService.LoginUserAsync(request);
            if (loginResponse == null)
                return Unauthorized("Invalid credentials");

            return Ok(loginResponse);
        }

        [HttpGet("profile/{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var profile = await _userService.GetUserProfileAsync(id);
            if (profile == null)
                return NotFound();

            return Ok(profile);
        }
    }
}
