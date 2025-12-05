using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.City.Request;
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityService.GetAllCitiesAsync());
        }

        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody] CityRequestDto dto)
        {
            await _cityService.AddUpdateCityAsync(dto);
            return Ok("Success");
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null) return NotFound();
            return Ok(city);
        }

        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] CityFilterDto filter)
        {
            return Ok(await _cityService.GetCityByFilterAsync(filter));
        }
    }
}
