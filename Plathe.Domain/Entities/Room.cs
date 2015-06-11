using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public Boolean WheelchairAccess { get; set; }
        public Boolean ThreeDimensional { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
        public int countRows { get; set; }
        public int countSeats { get; set; }
    }
}
