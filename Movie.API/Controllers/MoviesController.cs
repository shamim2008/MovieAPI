using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Dtos;
using Movie.API.Model;
using Movie.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }


        [HttpGet("{movieId:int}")]
        public async Task<ActionResult<Movies>> GetMoviesById(int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await movieRepository.GetMoviesById(movieId);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Movies>> SaveMovies([FromBody] Movies movies)
        {
            try
            {
                if (movies == null)
                {
                    return BadRequest();
                }

                var result = await movieRepository.SaveMovies(movies);
                return CreatedAtAction(nameof(GetMoviesById), new { movieId = result.MovieId }, result);
            }
            catch
            {

                return BadRequest();
            }


        }

        [HttpGet("stats")]
        public async Task<ActionResult> GetMoviesStats()
        {
            var result = await movieRepository.GetMovieStats();

            try
            {
                if (result != null)
                {

                    var newResult = result.GroupBy(x => x.MovieId).Select(x => new
                    {
                        MovieId = x.Key,
                        TotalWatchDuration = TimeSpan.FromMilliseconds((double)x.Sum(y => y.WatchDuration)).ToString("c"),
                        TotalPlayed = x.Count(),
                        AverageWatchDuration = TimeSpan.FromMilliseconds((double)x.Average(c => c.WatchDuration)).ToString("c")
                    }).ToList();

                    return Ok(newResult);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
