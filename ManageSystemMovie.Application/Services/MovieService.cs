using ManageSystemMovie.Application.Services.Interfaces;
using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Repository.General;
using ManageSystemMovie.Shared.Validator;
using Serilog;

namespace ManageSystemMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public MovieService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<Movie>> AddMovie(Movie movie)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidMovie = await IsValidMovieRequest(movie);

                if (!isValidMovie.Success)
                {
                    Log.Error("Message: Invalid inputs to Movie");
                    return Result<Movie>.Error(isValidMovie.Message);
                }

                movie.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.MovieRepository.AddMovieAsync(movie);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<Movie>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to add a new Movie " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var movieToDelete = await _repositoryUoW.MovieRepository.GetMovieByIdAsync(movieId);

                if (movieToDelete == null)
                {
                    Log.Error("Message: Error to delete to Movie");
                    throw new ArgumentException("Movie not found with the given ID.");
                }

                _repositoryUoW.MovieRepository.DeleteMovieAsync(movieToDelete);
                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to delete a Person " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Movie> GetAllMovieByName(string name)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    Log.Error("Name can not be empty or null!");
                    throw new InvalidOperationException("Name can not be empty or null!");
                }

                string newName = char.ToUpper(name[0]) + name.Substring(1);

                Movie movie = await _repositoryUoW.MovieRepository.GetMovieByNameAsync(newName);

                if (movie == null)
                {
                    Log.Error("Message: Error to load the Movie");
                    throw new InvalidOperationException("Movie not found!");
                }

                _repositoryUoW.Commit();
                return movie;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list Movie " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Movie> movieList = await _repositoryUoW.MovieRepository.GetAllMoviesAsync();
                _repositoryUoW.Commit();
                return movieList;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list Movie " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Result<Movie>> UpdateMovie(Movie movie)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidMovie = await IsValidMovieRequest(movie);

                if (!isValidMovie.Success)
                {
                    Log.Error("Message: Invalid inputs to Movie");
                    return Result<Movie>.Error(isValidMovie.Message);
                }

                var movieName = movie.Name;

                Movie movieByName = await _repositoryUoW.MovieRepository.GetMovieByNameAsync(movieName);

                if (movieName is null)
                {
                    Log.Error("Message: Error to update to Movie");
                    throw new InvalidOperationException("Movie does not found!");
                }

                movieByName.Director = movie.Director;
                movieByName.ModificationDate = DateTime.Now;

                var result = _repositoryUoW.MovieRepository.UpdateMovieAsync(movieByName);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return Result<Movie>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to update a Movie " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private async Task<Result<Movie>> IsValidMovieRequest(Movie movie)
        {
            var requestValidator = await new MovieRequestValidator().ValidateAsync(movie);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<Movie>.Error(errorMessage);
            }

            return Result<Movie>.Ok();
        }
    }
}