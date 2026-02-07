using Kemar.MBS.API.Core.Helper;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Admin.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] //Entire controller is Admin protected except login
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AdminLoginRequestDto request)
    {
        var result = await _adminService.LoginAdminAsync(request);
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AdminCreateRequestDto request)
    {
        var result = await _adminService.CreateAdminAsync(request);
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _adminService.GetAdminByIdAsync(id);
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _adminService.GetAllAdminsAsync();
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }

    [HttpGet("reports/daily")]
    public async Task<IActionResult> GetDailySummary([FromQuery] DateTime date)
    {
        var result = await _adminService.GetDailySummaryAsync(date);
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }

    [HttpGet("reports/show/{showId}")]
    public async Task<IActionResult> GetShowReport(int showId)
    {
        var result = await _adminService.GetShowReportAsync(showId);
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }

    [HttpGet("reports/movie/{movieId}")]
    public async Task<IActionResult> GetMovieReport(int movieId)
    {
        var result = await _adminService.GetMovieReportAsync(movieId);
        return CommonHelper.ReturnActionResultByStatus(result, this);
    }
}
