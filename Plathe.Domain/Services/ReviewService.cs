using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository repository;

        public ReviewService(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Review> GetReviewsByMovieId(int id)
        {
            return repository.Reviews.Where(m => m.Movie.MovieId == id);
        }

        public IEnumerable<Review> GetNewReviews()
        {
            return repository.Reviews.Where(m => m.ReviewStatus == 0);
        }

        public Review CreateReview(Review review)
        {
            return repository.SaveReview(review);
        }

        public Review SetStatusForReview(int reviewId, int newStatus)
        {
            return repository.SetStatus(reviewId, newStatus);
        }
    }
}
