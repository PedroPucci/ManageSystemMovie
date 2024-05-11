using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Connections;
using ManageSystemMovie.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageSystemMovie.Repository.Repository
{
    public class RoomMovieRepository : IRoomMovieRepository
    {
        private readonly DataContext _context;

        public RoomMovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RoomMovie> AddRoomMovieAsync(RoomMovie roomMovie)
        {
            var result = await _context.RoomMovie.AddAsync(roomMovie);
            return result.Entity;
        }

        public RoomMovie DeleteRoomMovieAsync(RoomMovie roomMovieDelete)
        {
            var response = _context.RoomMovie.Remove(roomMovieDelete);
            return response.Entity;
        }

        public async Task<List<RoomMovie>> GetAllRoomMoviesAsync()
        {
            return await _context.RoomMovie
                .OrderBy(roomMovie => roomMovie.Number)
                .Select(roomMovie => new RoomMovie
                {
                    Number = roomMovie.Number,
                    Description = roomMovie.Description
                }).ToListAsync();
            }

        public async Task<RoomMovie> GetRoomMovieByIdAsync(int? id)
        {
            return await _context.RoomMovie.FirstOrDefaultAsync(roomMovie => roomMovie.Id == id);
        }

        public async Task<RoomMovie> GetRoomMovieByNumberAsync(int numberRoomMovie)
        {
            return await _context.RoomMovie.FirstOrDefaultAsync(roomMovie => roomMovie.Number == numberRoomMovie);
        }

        public RoomMovie UpdateRoomMovieAsync(RoomMovie roomMovie)
        {
            var response = _context.RoomMovie.Update(roomMovie);
            return response.Entity;
        }
    }
}