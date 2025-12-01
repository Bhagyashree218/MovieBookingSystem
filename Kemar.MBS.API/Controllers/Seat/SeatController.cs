using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Seats.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SeatCreateRequestDto dto)
        {
            await _seatService.CreateSeatsAsync(dto);
            return Ok("Seats created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            if (seat == null) return NotFound();
            return Ok(seat);
        }

        [HttpGet("show/{showId}")]
        public async Task<IActionResult> GetByShow(int showId)
        {
            var seats = await _seatService.GetSeatsByShowIdAsync(showId);
            return Ok(seats);
        }
    }
}
