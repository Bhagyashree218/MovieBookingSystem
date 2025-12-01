using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Show.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ShowCreateRequestDto dto)
        {
            await _showService.CreateShowAsync(dto);
            return Ok("Show created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var show = await _showService.GetShowByIdAsync(id);
            if (show == null) return NotFound();
            return Ok(show);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var shows = await _showService.GetAllShowsAsync();
            return Ok(shows);
        }
    }
}
