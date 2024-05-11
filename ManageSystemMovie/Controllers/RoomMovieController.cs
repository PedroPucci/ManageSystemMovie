using ManageSystemMovie.Application.Services.General;
using ManageSystemMovie.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageSystemMovie.Controllers
{
    [ApiController]
    [Route("api/v1/RoomMovie")]
    public class RoomMovieController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public RoomMovieController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddRoomMovie([FromBody] RoomMovie roomMovie)
        {
            var result = await _serviceUoW.RoomMovieService.AddRoomMovie(roomMovie);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateMovie([FromBody] RoomMovie roomMovie)
        {
            RoomMovie updateRoomMovie = await _serviceUoW.RoomMovieService.UpdateRoomMovie(roomMovie);
            return Ok(updateRoomMovie);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteRoomMovie(int id)
        {
            await _serviceUoW.RoomMovieService.DeleteRoomMovieAsync(id);
            return Ok();
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Movie>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllRoomMovies()
        {
            var movies = await _serviceUoW.RoomMovieService.GetAllRoomMovies();
            return Ok(movies);
        }
    }
}