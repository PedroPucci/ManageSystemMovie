using ManageSystemMovie.Application.Services.General;
using ManageSystemMovie.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageSystemMovie.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class MovieController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public MovieController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            var result = await _serviceUoW.MovieService.AddMovie(movie);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateMovie([FromBody] Movie movie)
        {
           var result = await _serviceUoW.MovieService.UpdateMovie(movie);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _serviceUoW.MovieService.DeleteMovieAsync(id);
            return Ok();
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Movie>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMovie()
        {
            var movies = await _serviceUoW.MovieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Movie>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMovieByFirstName(string name)
        {
            var movies = await _serviceUoW.MovieService.GetAllMovieByName(name);
            return Ok(movies);
        }
    }
}