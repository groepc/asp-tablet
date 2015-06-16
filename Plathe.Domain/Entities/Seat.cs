using System;

namespace Plathe.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int RowId { get; set; }
        public Boolean Reserved { get; set; }
        public Boolean WheelChairSeat { get; set; }
        public Boolean PrioritySeat { get; set; }
        public virtual Row Row { get; set; }

    }
}
