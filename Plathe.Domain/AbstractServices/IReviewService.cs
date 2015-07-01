using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IReviewService
    {
        IEnumerable<Review> GetReviewsByMovieId(int id);
        
        IEnumerable<Review> GetNewReviews();

        Review CreateReview(Review review);

        Review SetStatusForReview(int reviewId, int newStatus);
    }
}