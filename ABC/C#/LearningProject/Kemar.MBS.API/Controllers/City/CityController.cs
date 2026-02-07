using Kemar.MBS.API.Core.Helper;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.City.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cityService.GetAllCitiesAsync();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody] CityRequestDto dto)
        {
            await _cityService.AddUpdateCityAsync(dto);
            return Ok(new { message = "Success" });
        }

        [AllowAnonymous]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null) return NotFound();

            return Ok(city);
        }

        [AllowAnonymous]
        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] CityFilterDto filter)
        {
            var result = await _cityService.GetCityByFilterAsync(filter);
            return Ok(result);
        }
    }
}
