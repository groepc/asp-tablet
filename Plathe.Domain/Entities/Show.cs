using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Plathe.Domain.Entities
{
    public class Show
    {
        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }

        [Display(Name = "Ondertiteling")]
        public string Subtitle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        [Display(Name = "Start tijd")]
        public DateTime StartingTime { get; set; }

        public string GetFormatedStartingTime
        {
            get
            {
                string currentDay = DateTime.Now.ToString("yyyy-MM-dd");
                string showDay = StartingTime.ToString("yyyy-MM-dd");

                if(currentDay == showDay)
                {
                    return "Vandaag om " + StartingTime.ToString("HH:mm");
                }
                return StartingTime.ToString("dd") + "-" + StartingTime.ToString("MM") + "-" + StartingTime.ToString("yyyy") + " om " + StartingTime.ToString("HH:mm");
            }
        }

        [Display(Name = "3D")]
        public Boolean ThreeDimensional { get; set; }

        //public Boolean TestProperty { get; set; }

        // holds the ID of the movie that will be played
        public virtual Movie Movie { get; set; }

        // holds the ID of the room the movie will be played
        public virtual Room Room { get; set; }

        // holds all the tickets for this show
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
