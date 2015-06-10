﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int ShowID { get; set; }
        public int ReservationID { get; set; }
        public int SeatID { get; set; }
        public string Type { get; set; }
        public string UniqueCode { get; set; }
        public Decimal Price { get; set; }
        public string Options { get; set; }
        public Boolean PopcornTime { get; set; }
        public DateTime? PrintedOn { get; set; }
        public virtual Show Show { get; set; }
        public virtual Reservation Reseveration { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
