using Plathe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plathe.DAL
{
    public class CinemaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
        {
            var movies = new List<Movie>
            {
                new Movie {
                    Title = "Shawshank Redemption",
                    Language = "Engels",
                    Duration = 120,
                    MinimumAge = 16,
                    Description = "Mooi verhaal",
                    ThreeDimensional = false,
                    Image = "http://placehold.it/250",
                    RatingViolence = true,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false
                },
                new Movie {
                    Title = "Catch me if you can",
                    Language = "Engels",
                    Duration = 120,
                    MinimumAge = 8,
                    Description = "Goed verhaal",
                    ThreeDimensional = false,
                    Image = "http://placehold.it/250",
                    RatingViolence = true,
                    RatingFear = false,
                    RatingSex = true,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false
                }
            };

            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();
        }
    }
}