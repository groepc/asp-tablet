﻿using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfMovieRepository : IMovieRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }

        public IEnumerable<Movie> GetMovieByGenreId(int genreId)
        {
            return context.Movies.Where(m => m.GenreId == genreId);
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.MovieId == 0)
            {
                context.Movies.Add(movie);
            }
            else
            {
                Movie dbEntry = context.Movies.Find(movie.MovieId);
                if (dbEntry != null)
                {
                    dbEntry.Title = movie.Title;
                    dbEntry.GenreId = movie.GenreId;
                    dbEntry.Language = movie.Language;
                    dbEntry.Duration = movie.Duration;
                    dbEntry.MinimumAge = movie.MinimumAge;
                    dbEntry.Description = movie.Description;
                    dbEntry.ThreeDimensional = movie.ThreeDimensional;
                    dbEntry.RatingViolence = movie.RatingViolence;
                    dbEntry.RatingFear = movie.RatingFear;
                    dbEntry.RatingSex = movie.RatingSex;
                    dbEntry.RatingDiscrimination = movie.RatingDiscrimination;
                    dbEntry.RatingDrugs = movie.RatingDrugs;
                    dbEntry.RatingLanguage = movie.RatingLanguage;
                    dbEntry.Director = movie.Director;
                    dbEntry.MainCharacters = movie.MainCharacters;
                    dbEntry.LinkToImdb = movie.LinkToImdb;
                    dbEntry.LinkToTrailer = movie.LinkToTrailer;
                    dbEntry.LinkToWebsite = movie.LinkToWebsite;
                    dbEntry.PlaysUntill = movie.PlaysUntill;

                }
            }
            context.SaveChanges();
        }
    }
}
