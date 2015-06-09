using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Moq;

namespace Plathe.UnitTests
{
    [TestClass]
    public class WebUIUnitTest
    {
        [TestMethod]
        public void Can_Filter_Genres()
        {
            //Arrange
            // - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[]{
            new Movie {MovieID = 1, Title = "Thor", GenreID = 1},
            new Movie {MovieID = 2, Title = "Loki", GenreID = 2},
            new Movie {MovieID = 3, Title = "Sif", GenreID = 3},
            new Movie {MovieID = 4, Title = "Odin", GenreID = 4},
            new Movie {MovieID = 5, Title = "Lagertha", GenreID = 5},
            new Movie {MovieID = 6, Title = "Shaun", GenreID = 6}
            });

            //Arrange
            // - create a new controller
            MovieController controller = new MovieController(mock.Object);

            //Action
            Movie[] result = ((GenreViewModel)controller.List(3).Model).Movies.ToArray();

            //Assert
            Assert.IsTrue(result[0].Title == "Thor");
            Assert.IsTrue(result[1].Title == "Sif");

        }
    }
}
