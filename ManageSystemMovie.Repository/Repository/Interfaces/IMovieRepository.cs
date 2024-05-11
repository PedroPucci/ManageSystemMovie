using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Repository.Repository.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> AddMovieAsync(Movie movie);
        Movie UpdateMovieAsync(Movie movie);
        Movie DeleteMovieAsync(Movie movieDelete);
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByNameAsync(string name);
        Task<Movie> GetMovieByIdAsync(int? id);
    }
}