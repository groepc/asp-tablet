using System;
using System.Data.Entity;

namespace Plathe.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public string UniqueCode { get; set; }
        public string SeatNumber { get; set; }
        public int Price { get; set; }
        public string Options { get; set; }
        public Boolean PopcornTime { get; set; }
        public DateTime PrintedOn { get; set; }

        public virtual Show Show { get; set; }
    }
}