using ManageSystemMovie.Application.Services.Interfaces;
using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Repository.General;

namespace ManageSystemMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public MovieService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Movie> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetAllMovieByNumber(int name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}