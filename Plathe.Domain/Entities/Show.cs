using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Show
    {
        public int ShowID { get; set; }
        public int MovieID { get; set; }
        public int RoomID { get; set; }

        [Display(Name = "Ondertiteling")]
        public string Subtitle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Start tijd")]
        public DateTime StartingTime { get; set; }

        public string getFormatedStartingTime
        {
            get
            {
                int currentDay = DateTime.Now.Day;
                int showDay = this.StartingTime.Day;

                if(currentDay == showDay)
                {
                    return "Vandaag om " + this.StartingTime.ToString("HH:mm");
                }
                else
                {
                    return this.StartingTime.Day.ToString() + "-" + this.StartingTime.Month.ToString() + " om " + this.StartingTime.ToString("HH:mm");
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
