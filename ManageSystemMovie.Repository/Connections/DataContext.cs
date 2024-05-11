using ManageSystemMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManageSystemMovie.Repository.Connections
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseMySql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<RoomMovie> RoomMovie { get; set; }
    }
}