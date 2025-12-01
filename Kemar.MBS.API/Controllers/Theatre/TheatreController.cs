using Kemar.MBS.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService _theatreService;

        public TheatreController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("city/{cityId}")]
        public async Task<IActionResult> GetByCity(int cityId)
        {
            return Ok(await _theatreService.GetTheatresByCityAsync(cityId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var theatre = await _theatreService.GetTheatreByIdAsync(id);
            if (theatre == null) return NotFound();
            return Ok(theatre);
        }
    }
}
