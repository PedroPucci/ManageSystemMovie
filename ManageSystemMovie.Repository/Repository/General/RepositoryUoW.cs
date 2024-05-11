using ManageSystemMovie.Repository.Connections;
using ManageSystemMovie.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace ManageSystemMovie.Repository.Repository.General
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataContext _context;
        private bool _disposed = false;
        private IRoomMovieRepository? _roomMovieRepository = null;
        private IMovieRepository? _movieRepository = null;

        public RepositoryUoW(DataContext context)
        {
            _context = context;
        }

        public IRoomMovieRepository RoomMovieRepository
        {
            get
            {
                if (_roomMovieRepository == null)
                {
                    _roomMovieRepository = new RoomMovieRepository(_context);
                }
                return _roomMovieRepository;
            }
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (_movieRepository == null)
                {
                    _movieRepository = new MovieRepository(_context);
                }
                return _movieRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}