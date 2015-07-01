using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Models
{
    public class MovieDetailViewModel
    {
        private IMovieService _movieService;
        private IReviewService _reviewService;
        private IShowService _showService;

        public MovieDetailViewModel()
        {
            _movieService = DependencyResolver.Current.GetService<IMovieService>();
            _showService = DependencyResolver.Current.GetService<IShowService>();
            _reviewService = DependencyResolver.Current.GetService<IReviewService>();
        }

        public Movie Movie { get; set; }

        public IEnumerable<Movie> Movies
        {
            get { return _movieService.GetAllMovies(); }
        }

        public IEnumerable<Show> ShowsForMovie
        {
            get { return _showService.GetShowsByMovieId(this.Movie.MovieId).ToList(); }
        }

        public IEnumerable<Review> ReviewsForMovie
        {
            get { 
                return _reviewService.GetReviewsByMovieId(this.Movie.MovieId)
                                .Where(m => m.ReviewStatus == 1)
                                .OrderByDescending(m => m.ReviewID)
                                .Take(5)
                                .ToList(); 
            }
        }

    }
}