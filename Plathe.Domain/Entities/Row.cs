using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Row
    {
        public int RowID { get; set; }
        public int RoomID { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
