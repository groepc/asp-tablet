using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
