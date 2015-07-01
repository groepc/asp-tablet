using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfReviewRepository : IReviewRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Review> Reviews
        {
            get { return context.Reviews; }
        }

        public Review SaveReview(Review review)
        {
            review.CreatedOn = DateTime.Now;

            context.Reviews.Add(review);
            context.SaveChanges();
            return review;
        }

        public Review SetStatus(int reviewId, int status)
        {
            var review = context.Reviews.First(m => m.ReviewID == reviewId);
            review.ReviewStatus = status;
            context.SaveChanges();

            return review;
        }
    }
}
