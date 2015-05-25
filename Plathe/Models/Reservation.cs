using System;
using System.Data.Entity;

namespace Plathe.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public string UniqueCode { get; set; }

        public Decimal PriceTotal { get; set; }

        public DateTime CreateOn { get; set; }

    }
}