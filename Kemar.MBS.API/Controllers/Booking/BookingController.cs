using System.Security.Claims;
using Kemar.MBS.Model.Booking.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User")]
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
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var booking = await _bookingService.CreateBookingAsync(dto, userId);
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
        return Ok(await _bookingService.GetBookingsByUserAsync(userId));
    }

    [AllowAnonymous]
    [HttpGet("booked-seats/{showId}")]
    public async Task<IActionResult> GetBookedSeats(int showId)
    {
        return Ok(await _bookingService.GetBookedSeatsByShowAsync(showId));
    }
}
