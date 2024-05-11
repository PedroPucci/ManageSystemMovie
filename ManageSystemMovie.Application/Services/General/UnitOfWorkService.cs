using ManageSystemMovie.Repository.Repository.General;

namespace ManageSystemMovie.Application.Services.General
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private RoomMovieService roomMovieService;
        private MovieService movieService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public RoomMovieService RoomMovieService
        {
            get
            {
                if (roomMovieService == null)
                {
                    roomMovieService = new RoomMovieService(_repositoryUoW);
                }
                return roomMovieService;
            }
        }

        public MovieService MovieService
        {
            get
            {
                if (movieService == null)
                {
                    movieService = new MovieService(_repositoryUoW);
                }
                return movieService;
            }
        }
    }
}