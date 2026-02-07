using Kemar.MBS.Model.Theatre.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class TheatreController : ControllerBase
{
    private readonly ITheatreService _theatreService;

    public TheatreController(ITheatreService theatreService)
    {
        _theatreService = theatreService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate([FromBody] TheatreRequestDto dto)
    {
        await _theatreService.AddUpdateAsync(dto);
        return Ok("Success");
    }

    [AllowAnonymous]
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _theatreService.GetTheatreByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("GetByCity/{cityId}")]
    public async Task<IActionResult> GetByCity(int cityId)
    {
        return Ok(await _theatreService.GetTheatreByCityAsync(cityId));
    }

    [AllowAnonymous]
    [HttpPost("GetByFilter")]
    public async Task<IActionResult> GetByFilter([FromBody] TheatreFilterDto filter)
    {
        return Ok(await _theatreService.GetTheatreByFilterAsync(filter));
    }
}
