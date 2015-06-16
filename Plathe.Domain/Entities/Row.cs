using System.Collections.Generic;

namespace Plathe.Domain.Entities
{
    public class Row
    {
        public int RowId { get; set; }
        public int RoomId { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
