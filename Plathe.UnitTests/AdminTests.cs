﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Abstract;
using Moq;
using Plathe.Domain.Entities;
using Plathe.WebUI.Controllers;
using System.Web.Mvc;

namespace Plathe.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Movies()
        {
            //Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[]
            {
                new Movie {MovieId = 1, Title = "Loki"},
                new Movie {MovieId = 2, Title = "Thor"},
                new Movie {MovieId = 3, Title = "Odin"},
            });

            //Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            //Action
            Movie[] result = ((IEnumerable<Movie>) target.Index().ViewData.Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("Loki", result[0].Title);
            Assert.AreEqual("Thor", result[1].Title);
            Assert.AreEqual("Odin", result[2].Title);

        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            //Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[]
            {
                new Movie {MovieId = 1, Title = "Loki"},
                new Movie {MovieId = 2, Title = "Thor"},
                new Movie {MovieId = 3, Title = "Odin"},
            });

            //Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            //Act
            Movie m1 = target.Edit(1).ViewData.Model as Movie;
            Movie m2 = target.Edit(2).ViewData.Model as Movie;
            Movie m3 = target.Edit(3).ViewData.Model as Movie;

            //Assert
            Assert.AreEqual(1, m1.MovieId);
            Assert.AreEqual(2, m2.MovieId);
            Assert.AreEqual(3, m3.MovieId);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Movie()
        {
            //Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[]
            {
                new Movie {MovieId = 1, Title = "Loki"},
                new Movie {MovieId = 2, Title = "Thor"},
                new Movie {MovieId = 3, Title = "Odin"},
            });

            //Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            //Act
            Movie result = (Movie) target.Edit(4).ViewData.Model;

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            //Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();

            //Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            //Arrange - create a movie
            Movie movie = new Movie {Title = "Test"};

            //Act - try to save the movie
            ActionResult result = target.Edit(movie);

            //Assert - check that the repository was called
            mock.Verify(m => m.SaveMovie(movie));
            //Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof (ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            //Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();

            //Arrange - create a controller
            AdminController target = new AdminController(mock.Object);

            //Arrange - create a movie
            Movie movie = new Movie {Title = "Test"};

            //Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");

            //Act - try to save the product
            ActionResult result = target.Edit(movie);

            //Assert - check that the repository was not called
            mock.Verify(m => m.SaveMovie(It.IsAny<Movie>()), Times.Never());

            //Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof (ViewResult));

        }
    }
}
