using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Plathe.Models
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