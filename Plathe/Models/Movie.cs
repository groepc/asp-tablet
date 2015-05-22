﻿using System;
using System.Data.Entity;

namespace Plathe.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Language { get; set; }
        public string Duration { get; set; }
        public int MinimumAge { get; set; }
        public string Description { get; set; }
        public Boolean ThreeDimensions { get; set; }
        public string Image { get; set; }
        public Boolean RatingViolence { get; set; }
        public Boolean RatingFear { get; set; }
        public Boolean RatingSex { get; set; }
        public Boolean RatingDiscrimination { get; set; }
        public Boolean RatingDrugs { get; set; }
        public Boolean RatingLanguage { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}