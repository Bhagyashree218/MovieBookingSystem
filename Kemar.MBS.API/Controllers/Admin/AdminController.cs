using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Admin.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginRequestDto request)
        {
            var admin = await _adminService.LoginAdminAsync(request);
            if (admin == null) return Unauthorized("Invalid Admin Credentials");

            return Ok(admin);
        }
    }
}
