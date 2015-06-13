using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Row
    {
        public int RowId { get; set; }
        public int RoomId { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
