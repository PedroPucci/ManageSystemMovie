using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Connections;
using ManageSystemMovie.Repository.Repository.Interfaces;

namespace ManageSystemMovie.Repository.Repository
{
    public class RoomMovieRepository : IRoomMovieRepository
    {
        private readonly DataContext _context;

        public RoomMovieRepository(DataContext context)
        {
            _context = context;
        }

        public Task<RoomMovie> AddRoomMovieAsync(RoomMovie roomMovie)
        {
            throw new NotImplementedException();
        }

        public RoomMovie DeleteRoomMovieAsync(RoomMovie roomMovieDelete)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomMovie>> GetAllRoomMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomMovie> GetRoomMovieByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<RoomMovie> GetRoomMovieByNumberAsync(int numberRoomMovie)
        {
            throw new NotImplementedException();
        }

        public RoomMovie UpdateRoomMovieAsync(RoomMovie roomMovie)
        {
            throw new NotImplementedException();
        }
    }
}