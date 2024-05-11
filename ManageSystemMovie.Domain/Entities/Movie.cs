using ManageSystemMovie.Domain.General;

namespace ManageSystemMovie.Domain.Entities
{
    public class Movie : BaseEntity
    {        
        public string? Name { get; set; }
        public string? Director { get; set; }
        public int TimeMovie { get; set; }
    }
}