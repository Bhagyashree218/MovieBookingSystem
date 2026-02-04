using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Movie.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [Authorize(Roles = "Admin")]
        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody] MovieRequestDto dto)
        {
            await _movieService.AddUpdateAsync(dto);
            return Ok("Success");
        }

        [AllowAnonymous]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] MovieFilterDto filter)
        {
            var movies = await _movieService.GetMovieByFilterAsync(filter);
            return Ok(movies);
        }
    }
}
