using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Movie.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] MovieCreateRequestDto dto)
        {
            await _movieService.CreateMovieAsync(dto);
            return Ok("Movie created successfully");
        }

        //[HttpPut("update")]
        //public async Task<IActionResult> Update([FromBody] MovieUpdateRequestDto dto)
        //{
        //    await _movieService.UpdateMovieAsync(dto);
        //    return Ok("Movie updated successfully");
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }
    }
}
