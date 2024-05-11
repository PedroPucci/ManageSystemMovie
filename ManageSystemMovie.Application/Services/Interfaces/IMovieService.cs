using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<Result<Movie>> AddMovie(Movie movie);
        Task<Result<Movie>> UpdateMovie(Movie movie);
        Task DeleteMovieAsync(int movieId);
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetAllMovieByName(string name);
    }
}