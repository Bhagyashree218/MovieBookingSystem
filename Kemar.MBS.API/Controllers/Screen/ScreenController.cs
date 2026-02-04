using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Screen.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class ScreenController : ControllerBase
{
    private readonly IScreenService _screenService;

    public ScreenController(IScreenService screenService)
    {
        _screenService = screenService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate([FromBody] ScreenRequestDto dto)
    {
        await _screenService.AddUpdateAsync(dto);
        return Ok("Success");
    }

    [AllowAnonymous]
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _screenService.GetScreenByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("GetByTheatre/{theatreId}")]
    public async Task<IActionResult> GetByTheatre(int theatreId)
    {
        return Ok(await _screenService.GetScreensByTheatreAsync(theatreId));
    }

    [AllowAnonymous]
    [HttpPost("GetByFilter")]
    public async Task<IActionResult> GetByFilter([FromBody] ScreenFilterDto filter)
    {
        return Ok(await _screenService.GetScreenByFilterAsync(filter));
    }
}
