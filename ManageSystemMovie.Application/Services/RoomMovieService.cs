using ManageSystemMovie.Application.Services.Interfaces;
using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Repository.General;

namespace ManageSystemMovie.Application.Services
{
    public class RoomMovieService : IRoomMovieService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public RoomMovieService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<RoomMovie> AddRoomMovie(RoomMovie roomMovie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoomMovieAsync(int roomMovieId)
        {
            throw new NotImplementedException();
        }

        public Task<RoomMovie> GetAllRoomMovieByNumber(int name)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomMovie>> GetAllRoomMovies()
        {
            throw new NotImplementedException();
        }

        public Task<RoomMovie> UpdateRoomMovie(RoomMovie roomMovie)
        {
            throw new NotImplementedException();
        }
    }
}