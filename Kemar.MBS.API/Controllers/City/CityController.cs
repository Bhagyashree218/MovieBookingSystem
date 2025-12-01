using Kemar.MBS.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityService.GetAllCitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null) return NotFound();
            return Ok(city);
        }
    }
}
