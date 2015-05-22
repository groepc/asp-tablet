using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Plathe.Models
{
    public class Show
    {
        public int ID { get; set; }
        public string Subtitle { get; set; }
        public string StartingTime { get; set; }
        public int ThreeDimensional { get; set; }

        // holds all the tickets for this show
        public virtual ICollection<Ticket> Tickets { get; set; }

        // holds the ID of the movie that will be played
        public virtual Movie Movie { get; set; }
    }
}