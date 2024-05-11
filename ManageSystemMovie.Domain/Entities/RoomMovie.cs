using ManageSystemMovie.Domain.General;

namespace ManageSystemMovie.Domain.Entities
{
    public class RoomMovie : BaseEntity
    {
        public int Number { get; set; }
        public string? Description { get; set; }        
    }
}