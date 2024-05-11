using ManageSystemMovie.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace ManageSystemMovie.Repository.Repository.General
{
    public interface IRepositoryUoW
    {
        IRoomMovieRepository RoomMovieRepository { get; }
        IMovieRepository MovieRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}