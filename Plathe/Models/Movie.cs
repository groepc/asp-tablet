using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Plathe.Models
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
    }
}