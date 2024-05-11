using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovieAsync(int movieId);
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetAllMovieByNumber(int name);
    }
}