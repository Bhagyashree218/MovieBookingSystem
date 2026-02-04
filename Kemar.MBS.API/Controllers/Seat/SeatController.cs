using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Seats.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody] SeatRequestDto dto)
        {
            await _seatService.AddUpdateAsync(dto);
            return Ok("Seats saved successfully");
        }

        [AllowAnonymous]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            if (seat == null) return NotFound();
            return Ok(seat);
        }

        [AllowAnonymous]
        [HttpGet("GetByScreen/{screenId}")]
        public async Task<IActionResult> GetByScreen(int screenId)
        {
            var seats = await _seatService.GetSeatsByScreenIdAsync(screenId);
            return Ok(seats);
        }

        [AllowAnonymous]
        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] SeatFilterDto filter)
        {
            var seats = await _seatService.GetSeatByFilterAsync(filter);
            return Ok(seats);
        }
    }
}
