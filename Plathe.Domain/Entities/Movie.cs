using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Plathe.Domain.Entities
{
    public class Movie
    {
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Nummer")]
        public int MovieId { get; set; }

        public int GenreId { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Vul een titel in.")]
        public string Title { get; set; }

        [Display(Name = "Taal")]
        [Required(ErrorMessage = "Vul een taal in.")]
        public string Language { get; set; }

        [Display(Name = "Duur in minuten")]
        [Required(ErrorMessage = "Vul de duur in minuten in.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Vul een minimale leeftijd in.")]
        [Display(Name = "Leeftijd vanaf")]
        public int MinimumAge { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Vul een omschrijving in.")]
        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Display(Name = "3D")]
        public Boolean ThreeDimensional { get; set; }

        [Display(Name = "Link naar afbeelding")]
        public string Image { get; set; }

        [Display(Name = "Rating geweld")]
        public Boolean RatingViolence { get; set; }

        [Display(Name = "Rating angst")]
        public Boolean RatingFear { get; set; }

        [Display(Name = "Rating seks")]
        public Boolean RatingSex { get; set; }

        [Display(Name = "Rating discriminatie")]
        public Boolean RatingDiscrimination { get; set; }

        [Display(Name = "Rating drugs")]
        public Boolean RatingDrugs { get; set; }

        [Display(Name = "Rating ongewenst taalgebruik")]
        public Boolean RatingLanguage { get; set; }

        [Display(Name = "Regisseur")]
        [Required(ErrorMessage = "Vul een regisseur in.")]
        public string Director { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Acteurs")]
        [Required(ErrorMessage = "Vul de namen van een aantal hoofdrolspelers in.")]
        public string MainCharacters { get; set; }

        [Display(Name = "Link naar IMDB")]
        public string LinkToImdb { get; set; }

        [Display(Name = "Link naar trailer")]
        public string LinkToTrailer { get; set; }

        [Display(Name = "Link naar officiële website")]
        public string LinkToWebsite { get; set; }

        [Display(Name = "Draait tot en met")]
        [Required(ErrorMessage = "Vul de uiterste vertoondatum in.")]
        public DateTime PlaysUntill { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Genre Genre { get; set; }
    }
}