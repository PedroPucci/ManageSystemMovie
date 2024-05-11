using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Connections;
using ManageSystemMovie.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageSystemMovie.Repository.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            var result = await _context.Movie.AddAsync(movie);
            return result.Entity;
        }

        public Movie DeleteMovieAsync(Movie movieDelete)
        {            
            var response = _context.Movie.Remove(movieDelete);
            return response.Entity;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movie
                .OrderBy(movie => movie.Name)
                .Select(movie => new Movie
                {
                    Name = movie.Name,
                    Director = movie.Director
                }).ToListAsync();
        }

        public async Task<Movie> GetMovieByNameAsync(string name)
        {
            return await _context.Movie.FirstOrDefaultAsync(movie => movie.Name == name);
        }

        public Movie UpdateMovieAsync(Movie movie)
        {
            var response = _context.Movie.Update(movie);
            return response.Entity;
        }

        public async Task<Movie> GetMovieByIdAsync(int? id)
        {
            return await _context.Movie.FirstOrDefaultAsync(movie => movie.Id == id);
        }
    }
}