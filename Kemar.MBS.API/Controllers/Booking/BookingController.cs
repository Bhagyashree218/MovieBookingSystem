using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Booking.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BookingRequestDto dto)
        {
            var booking = await _bookingService.CreateBookingAsync(dto);
            return Ok(booking);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserAsync(userId);
            return Ok(bookings);
        }
    }
}
