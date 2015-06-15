using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Moq;
using Plathe.UnitTest.Controllers;
using Plathe.UnitTest.Models;

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
            new Movie {MovieId = 1, Title = "Thor", GenreId = 1},
            new Movie {MovieId = 2, Title = "Loki", GenreId = 2},
            new Movie {MovieId = 3, Title = "Sif", GenreId = 3},
            new Movie {MovieId = 4, Title = "Odin", GenreId = 4},
            new Movie {MovieId = 5, Title = "Lagertha", GenreId = 5},
            new Movie {MovieId = 6, Title = "Shaun", GenreId = 6}
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
