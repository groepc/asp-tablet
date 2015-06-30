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
                int currentDay = DateTime.Now.Day;
                int showDay = StartingTime.Day;

                if(currentDay == showDay)
                {
                    return "Vandaag om " + StartingTime.ToString("HH:mm");
                }
                else
                {
                    return StartingTime.Day.ToString() + "-" + StartingTime.Month.ToString() + "-" + StartingTime.Year.ToString() + " om " + StartingTime.ToString("HH:mm");
                }
            }
        }

        public string GetIsoStartingTime
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
                    return StartingTime.Day.ToString() + "-" + StartingTime.Month.ToString() + "-" + StartingTime.Year.ToString() + " " + StartingTime.ToString("HH:mm");
                }
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
