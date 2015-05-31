using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Seat
    {
        public int SeatID { get; set; }
        public int RowID { get; set; }
        public Boolean Reserved { get; set; }
        public Boolean WheelChairSeat { get; set; }
        public Boolean PrioritySeat { get; set; }
        public virtual Row Row { get; set; }

    }
}
