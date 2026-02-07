using Logistics.Api.Models;
using Logistics.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var vehicles = await _vehicleService.GetAvailableVehiclesAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            var newVehicle = await _vehicleService.AddVehicleAsync(vehicle);
            return CreatedAtAction(nameof(GetVehicle), new { id = newVehicle.VehicleId }, newVehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
        {
            var updated = await _vehicleService.UpdateVehicleAsync(id, vehicle);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var deleted = await _vehicleService.DeleteVehicleAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
