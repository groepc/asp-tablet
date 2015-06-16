using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Plathe.Domain.Entities
{
    public class Movie
    {
        
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }

        public int GenreId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Duration { get; set; }
        public int MinimumAge { get; set; }

        [DataType(DataType.MultilineText)]
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

        [DataType(DataType.MultilineText)]
        public string MainCharacters { get; set; }

        public string LinkToImdb { get; set; }
        public string LinkToTrailer { get; set; }
        public string LinkToWebsite { get; set; }
        public DateTime PlaysUntill { get; set; }

        [HiddenInput(DisplayValue = true)]
        public Genre Genre { get; set; }
    }
}