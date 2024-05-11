using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Repository.Repository.Interfaces
{
    public interface IRoomMovieRepository
    {
        Task<RoomMovie> AddRoomMovieAsync(RoomMovie roomMovie);
        RoomMovie UpdateRoomMovieAsync(RoomMovie roomMovie);
        RoomMovie DeleteRoomMovieAsync(RoomMovie roomMovieDelete);
        Task<List<RoomMovie>> GetAllRoomMoviesAsync();
        Task<RoomMovie> GetRoomMovieByNumberAsync(int numberRoomMovie);
        Task<RoomMovie> GetRoomMovieByIdAsync(int? id);
    }
}