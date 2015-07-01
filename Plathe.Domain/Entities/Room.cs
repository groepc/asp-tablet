using System;
using System.Collections.Generic;

namespace Plathe.Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public Boolean WheelchairAccess { get; set; }
        public Boolean ThreeDimensional { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
        public int CountRows { get; set; }
        public int CountSeats { get; set; }

        public int TotalSeats
        {
            get { return CountRows * CountSeats; }
        }
    }
}
