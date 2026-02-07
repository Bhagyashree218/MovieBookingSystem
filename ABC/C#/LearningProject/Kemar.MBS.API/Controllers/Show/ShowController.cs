using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Show.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class ShowController : ControllerBase
{
    private readonly IShowService _showService;

    public ShowController(IShowService showService)
    {
        _showService = showService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate([FromBody] ShowRequestDto dto)
    {
        await _showService.AddUpdateAsync(dto);
        return Ok("Success");
    }

    [AllowAnonymous]
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _showService.GetShowByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _showService.GetAllShowsAsync());
    }

    [AllowAnonymous]
    [HttpPost("GetByFilter")]
    public async Task<IActionResult> GetByFilter([FromBody] ShowFilterDto filter)
    {
        return Ok(await _showService.GetShowByFilterAsync(filter));
    }
}
