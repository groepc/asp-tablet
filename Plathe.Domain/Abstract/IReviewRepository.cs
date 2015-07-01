using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Reviews { get; }
        Review SaveReview(Review review);
        Review SetStatus(int reviewId, int status);
    }
}
