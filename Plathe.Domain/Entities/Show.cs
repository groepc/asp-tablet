using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plathe.Domain.Entities
{
    public class Show
    {
        public int ShowId { get; set; }

        [Display(Name = "Film")]
        public int MovieId { get; set; }

        [Display(Name = "Zaal")]
        public int RoomId { get; set; }

        [Display(Name = "Ondertiteling")]
        public string Subtitle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Starttijd")]
        public DateTime StartingTime { get; set; }

        public string GetFormatedStartingTime
        {
            get
            {
                int currentDay = DateTime.Now.Day;
                int showDay = StartingTime.Day;

                if (currentDay == showDay)
                {
                    return "Vandaag om " + StartingTime.ToString("HH:mm");
                }
                else
                {
                    return StartingTime.Day.ToString() + "-" + StartingTime.Month.ToString() + " om " + StartingTime.ToString("HH:mm");
                }
            }
        }

        [Display(Name = "3D")]
        public Boolean ThreeDimensional { get; set; }

        // holds the ID of the movie that will be played
        public virtual Movie Movie { get; set; }

        // holds the ID of the room the movie will be played
        public virtual Room Room { get; set; }

        // holds all the tickets for this show
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
