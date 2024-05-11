using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Application.Services.Interfaces
{
    public interface IRoomMovieService
    {
        Task<Result<RoomMovie>> AddRoomMovie(RoomMovie roomMovie);
        Task<RoomMovie> UpdateRoomMovie(RoomMovie roomMovie);
        Task DeleteRoomMovieAsync(int roomMovieId);
        Task<List<RoomMovie>> GetAllRoomMovies();
        Task<RoomMovie> GetAllRoomMovieByNumber(int number);
    }
}