using Logistics.Api.Models;
using Logistics.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriversController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            var newDriver = await _driverService.AddDriverAsync(driver);
            return CreatedAtAction(nameof(GetDriver), new { id = newDriver.DriverId }, newDriver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            var updated = await _driverService.UpdateDriverAsync(id, driver);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var deleted = await _driverService.DeleteDriverAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
