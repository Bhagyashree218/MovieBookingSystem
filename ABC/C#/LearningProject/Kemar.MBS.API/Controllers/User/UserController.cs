using Kemar.MBS.API.Core.Helper;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.User.Request;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var result = await _userService.RegisterUserAsync(request);
            return CommonHelper.ReturnActionResultByStatus(result, this);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _userService.LoginUserAsync(request);
            return CommonHelper.ReturnActionResultByStatus(result, this);
        }

        [Authorize(Roles ="User")]
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var result = await _userService.GetUserProfileAsync(id);
            return CommonHelper.ReturnActionResultByStatus(result, this);
        }
    }
}
