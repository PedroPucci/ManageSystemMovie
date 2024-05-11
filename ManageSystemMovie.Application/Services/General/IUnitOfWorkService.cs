namespace ManageSystemMovie.Application.Services.General
{
    public interface IUnitOfWorkService
    {
        RoomMovieService RoomMovieService { get; }
        MovieService MovieService { get; }
    }
}