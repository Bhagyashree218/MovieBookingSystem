using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Theatre.Request;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TheatreController : ControllerBase
{
    private readonly ITheatreService _theatreService;

    public TheatreController(ITheatreService theatreService)
    {
        _theatreService = theatreService;
    }

    [HttpPost("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate([FromBody] TheatreRequestDto dto)
    {
        await _theatreService.AddUpdateAsync(dto);
        return Ok("Success");
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _theatreService.GetTheatreByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("GetByCity/{cityId}")]
    public async Task<IActionResult> GetByCity(int cityId)
    {
        return Ok(await _theatreService.GetTheatreByCityAsync(cityId));
    }

    [HttpPost("GetByFilter")]
    public async Task<IActionResult> GetByFilter([FromBody] TheatreFilterDto filter)
    {
        return Ok(await _theatreService.GetTheatreByFilterAsync(filter));
    }
}
