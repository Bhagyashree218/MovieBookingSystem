using Kemar.MBS.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        [HttpGet("theatre/{theatreId}")]
        public async Task<IActionResult> GetByTheatre(int theatreId)
        {
            return Ok(await _screenService.GetScreensByTheatreAsync(theatreId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var screen = await _screenService.GetScreenByIdAsync(id);
            if (screen == null) return NotFound();
            return Ok(screen);
        }
    }
}
