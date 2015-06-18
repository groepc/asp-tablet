using System;
using System.Collections.Generic;
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
        public void Can_Create_Genres()
        {
            //Arrange
            // - create the mock repository
            Mock<IGenreRepository> mock = new Mock<IGenreRepository>();
            mock.Setup(m => m.Genres).Returns(new Genre[]{
            new Genre {GenreId = 1, Name = "Thor"},
            new Genre {GenreId = 2, Name = "Odin"},
            new Genre {GenreId = 3, Name = "Loki"},
            new Genre {GenreId = 4, Name = "Odin"}
            });

            //Arrange
            // - create a new controller
            NavController target = new NavController(mock.Object);

            //Action
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            //Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Thor");
            Assert.AreEqual(results[1], "Loki");
            Assert.AreEqual(results[2], "Odin");
        }
    }
}
