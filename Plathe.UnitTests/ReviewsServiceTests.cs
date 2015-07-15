using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Plathe.Domain.Services;

namespace Plathe.UnitTests
{
    [TestClass]
    public class ReviewsServiceTests
    {

        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

        public ReviewsServiceTests()
        {
            // arrange - create mock repository with fake data
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review
                {
                    ReviewStatus = 0,
                    Content = "Dit is review in afwachting op goedkeuring!",
                    Rating = 2,
                    UserEmail = "email@info.nl",
                    UserName = "Vadiem Janssens",
                    MovieID = 1,
                    CreatedOn = DateTime.Today.AddHours(13)
                },
                new Review
                {
                    ReviewStatus = 1,
                    Content = "Dit een approved review!",
                    Rating = 5,
                    UserEmail = "email@info.nl",
                    UserName = "Vadiem Janssens",
                    MovieID = 2,
                    CreatedOn = DateTime.Today.AddHours(13)
                },
                new Review
                {
                    ReviewStatus = -1,
                    Content = "Deze review is afgekeurd!",
                    Rating = 1,
                    UserEmail = "email@info.nl",
                    UserName = "Vadiem Janssens",
                    MovieID = 1,
                    CreatedOn = DateTime.Today.AddHours(13)
                }
            });
        }

        [TestMethod]
        public void Fetch_Only_New_Reviews()
        {

            // arrange - create ReviewService object
            ReviewService target =  new ReviewService(mock.Object);

            // act - get only new reviews (where reviewstatus == 0)
            var newReviews = target.GetNewReviews().ToArray();

            // assert - check if the amount reviews is equal to 1
            Assert.AreEqual(newReviews.Length, 1);
        }

        [TestMethod]
        public void Fetch_Reviews_By_MovieId()
        {
            // arrange - create ReviewService object
            ReviewService target = new ReviewService(mock.Object);

            // act - get only reviews for certain movie
            var reviewsForMovie = target.GetReviewsByMovieId(1).ToArray();

            // assert - check if the amount reviews is equal to 2
            Assert.AreEqual(reviewsForMovie.Length, 2);
        }

        [TestMethod]
        public void Save_New_Review()
        {
            // arrange - set up new reivew
            Review newReview = new Review
            {
                ReviewID = 999,
                Content = "Nieuwe review",
                CreatedOn = DateTime.Today,
                MovieID = 1,
                Rating = 4,
                ReviewStatus = 0,
                UserEmail = "email@info.nl",
                UserName = "Vadiem Janssens"
            };

            // arrange - create ReviewService object
            ReviewService target = new ReviewService(mock.Object);

            // act - save new review
            var result = target.CreateReview(newReview);

            // assert - check that the repository is called
            mock.Verify(m => m.SaveReview(newReview));
        }
    }
}