using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Duration { get; set; }
        public int MinimumAge { get; set; }
        public string Description { get; set; }
        public Boolean ThreeDimensional { get; set; }
        public string Image { get; set; }
        public Boolean RatingViolence { get; set; }
        public Boolean RatingFear { get; set; }
        public Boolean RatingSex { get; set; }
        public Boolean RatingDiscrimination { get; set; }
        public Boolean RatingDrugs { get; set; }
        public Boolean RatingLanguage { get; set; }
        public string Director { get; set; }
        public string MainCharacters { get; set; }
        public string linkToImdb { get; set; }
        public string linkToTrailer { get; set; }
        public string linkToWebsite { get; set; }
        public DateTime playsUntill { get; set; }
        public string Genre { get; set; }
    }
}