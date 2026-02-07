using Logistics.Api.Models;
using Logistics.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripService _tripService;

        public TripsController(TripService tripService)
        {
            _tripService = tripService;
        }

        // GET /api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
        {
            var trips = await _tripService.GetAllTripsAsync();
            return Ok(trips);
        }

        // 🟢 POST /api/Trips
        [HttpPost]
        public async Task<IActionResult> CreateTrip(Trip trip)
        {
            var newTrip = await _tripService.CreateTripAsync(trip);
            if (newTrip == null)
                return BadRequest("Invalid Driver/Vehicle or unavailable.");

            return CreatedAtAction(nameof(GetAllTrips), new { id = newTrip.TripId }, newTrip);
        }

        // 🟢 PUT /api/Trips/{id}/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTrip(int id)
        {
            var result = await _tripService.CompleteTripAsync(id);
            if (!result)
                return NotFound("Trip not found.");

            return NoContent();
        }

        // 🟢 GET /api/Trips/long
        [HttpGet("long")]
        public async Task<IActionResult> GetLongTrips()
        {
            var trips = await _tripService.GetLongTripsAsync();
            return Ok(trips);
        }

        // 🟢 GET /api/Drivers/{id}/trips
        [HttpGet("/api/Drivers/{driverId}/trips")]
        public async Task<IActionResult> GetTripsByDriver(int driverId)
        {
            var trips = await _tripService.GetTripsByDriverAsync(driverId);
            return Ok(trips);
        }
    }
}
