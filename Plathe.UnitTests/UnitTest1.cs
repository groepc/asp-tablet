using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Moq;
using Plathe.WebUI.Controllers;
using Plathe.WebUI.Models;

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
            Mock<IGenreRepository> mock = new Mock<IGenreRepository>();
            mock.Setup(m => m.Genres).Returns(new Genre[]{
            new Genre {GenreId = 1, Name = "Thor"},
            new Genre {GenreId = 1, Name = "Odin"},
            new Genre {GenreId = 1, Name = "Loki"},
            });

            //Arrange
            // - create a new controller
            NavController controller = new NavController(mock.Object);

            //Action
            //Movie[] result = ((GenreViewModel)controller.List(3).Model).Genres.ToArray();

            //Assert
            //Assert.IsTrue(result[0].Title == "Thor");
            //Assert.IsTrue(result[1].Title == "Sif");

        }
    }
}
