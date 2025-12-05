using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Screen.Request;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ScreenController : ControllerBase
{
    private readonly IScreenService _screenService;

    public ScreenController(IScreenService screenService)
    {
        _screenService = screenService;
    }

    [HttpPost("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate([FromBody] ScreenRequestDto dto)
    {
        await _screenService.AddUpdateAsync(dto);
        return Ok("Success");
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _screenService.GetScreenByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("GetByTheatre/{theatreId}")]
    public async Task<IActionResult> GetByTheatre(int theatreId)
    {
        return Ok(await _screenService.GetScreensByTheatreAsync(theatreId));
    }

    [HttpPost("GetByFilter")]
    public async Task<IActionResult> GetByFilter([FromBody] ScreenFilterDto filter)
    {
        return Ok(await _screenService.GetScreenByFilterAsync(filter));
    }
}
