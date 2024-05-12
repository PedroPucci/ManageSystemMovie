using ManageSystemMovie.Application.Services.Interfaces;
using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Repository.Repository.General;
using ManageSystemMovie.Shared.Validator;
using Serilog;

namespace ManageSystemMovie.Application.Services
{
    public class RoomMovieService : IRoomMovieService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public RoomMovieService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<RoomMovie>> AddRoomMovie(RoomMovie roomMovie)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidRoomMovie = await IsValidRoomMovieRequest(roomMovie);

                if (!isValidRoomMovie.Success)
                {
                    Log.Error("Message: Invalid inputs to RoomMovie");
                    return Result<RoomMovie>.Error(isValidRoomMovie.Message);
                }

                roomMovie.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.RoomMovieRepository.AddRoomMovieAsync(roomMovie);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<RoomMovie>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to add a new Person " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Add with success RoomMovie");
                transaction.Dispose();
            }
        }

        public async Task DeleteRoomMovieAsync(int roomMovieId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var roomMovieToDelete = await _repositoryUoW.RoomMovieRepository.GetRoomMovieByIdAsync(roomMovieId);

                if (roomMovieToDelete == null)
                {
                    Log.Error("Message: Error to delete to RoomMovie");
                    throw new ArgumentException("RoomMovie not found with the given ID.");
                }

                _repositoryUoW.RoomMovieRepository.DeleteRoomMovieAsync(roomMovieToDelete);
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
                Log.Error("Message: Delete with success RoomMovie");
                transaction.Dispose();
            }
        }

        public async Task<RoomMovie> GetAllRoomMovieByNumber(int number)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                RoomMovie roomMovie = await _repositoryUoW.RoomMovieRepository.GetRoomMovieByNumberAsync(number);

                if (roomMovie == null)
                {
                    Log.Error("Message: Error to load the RoomMovie");
                    throw new InvalidOperationException("RoomMovie not found!");
                }

                _repositoryUoW.Commit();
                return roomMovie;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list Person " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: GetAllRoomMovieByNumber with success RoomMovie");
                transaction.Dispose();
            }
        }

        public async Task<List<RoomMovie>> GetAllRoomMovies()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<RoomMovie> roomMovieList = await _repositoryUoW.RoomMovieRepository.GetAllRoomMoviesAsync();
                _repositoryUoW.Commit();
                return roomMovieList;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list RoomMovie " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: GetAll with success RoomMovie");
                transaction.Dispose();
            }
        }

        public async Task<RoomMovie> UpdateRoomMovie(RoomMovie roomMovie)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var numberMovie = roomMovie.Number;

                RoomMovie roomMovieByNumber = await _repositoryUoW.RoomMovieRepository.GetRoomMovieByNumberAsync(numberMovie);

                if (roomMovieByNumber is null)
                {
                    Log.Error("Message: Error to update to RoomMovie");
                    throw new InvalidOperationException("RoomMovie does not found!");
                }

                roomMovieByNumber.Description = roomMovie.Description;
                roomMovieByNumber.ModificationDate = DateTime.Now;

                var result = _repositoryUoW.RoomMovieRepository.UpdateRoomMovieAsync(roomMovieByNumber);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to update a RoomMovie " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Upated with success RoomMovie");
                transaction.Dispose();
            }
        }

        private async Task<Result<RoomMovie>> IsValidRoomMovieRequest(RoomMovie roomMovie)
        {
            var requestValidator = await new RoomMovieRequestValidator().ValidateAsync(roomMovie);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<RoomMovie>.Error(errorMessage);
            }

            return Result<RoomMovie>.Ok();
        }
    }
}