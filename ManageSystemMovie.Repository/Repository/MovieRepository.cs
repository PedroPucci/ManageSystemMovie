using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Connections;
using ManageSystemMovie.Repository.Repository.Interfaces;

namespace ManageSystemMovie.Repository.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Movie> AddMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie DeleteMovieAsync(Movie movieDelete)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}