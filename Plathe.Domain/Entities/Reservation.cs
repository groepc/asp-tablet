using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string UniqueCode { get; set; }
        public Decimal PriceTotal { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
