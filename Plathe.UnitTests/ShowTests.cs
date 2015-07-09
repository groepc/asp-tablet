using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.Domain.Services;

namespace Plathe.UnitTests
{
    [TestClass]
    public class ShowTests
    {

        private Mock<IMovieRepository> _movieMock;
        private Mock<IShowRepository> _showMock;
        private IShowService _showService;

        [TestInitialize]
        public void Initialize()
        {
            _movieMock = new Mock<IMovieRepository>();
            _showMock = new Mock<IShowRepository>();
            _showService = new ShowService(_showMock.Object, _movieMock.Object);
            _movieMock.Setup(m => m.Movies).Returns(new[]
            {
                new Movie
                {
                    MovieId = 1,
                    Title = "Fast and Furious 7",
                    Duration = 120
                }
            });
            _movieMock.Setup(m => m.FindMovieById(1)).Returns(
                new Movie
                {
                    MovieId = 1,
                    Title = "Fast and Furious 7",
                    Duration = 120
                }
            );
        }

        [TestMethod]
        public void AddShowInPast()
        {

            var result = _showService.SaveShow(1, 1, 1, "nl", new DateTime(2015, 01, 01), false);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AddShowOnSameTime()
        {

            _showMock.Setup(m => m.Shows).Returns(new[]
            {
                new Show
                {
                    ShowId = 1,
                    MovieId = 1,
                    RoomId = 1,
                    StartingTime = DateTime.Today.AddDays(1).AddHours(18).AddMinutes(30),
                    ThreeDimensional = false
                }
            });

            ShowService showService = new ShowService(_showMock.Object, _movieMock.Object);

            var result = showService.SaveShow(1, 1, 1, "nl", DateTime.Today.AddDays(1).AddHours(20).AddMinutes(30), false);

            Assert.AreEqual(2, result);

        }


        [TestMethod]
        public void AddShow()
        {
            var result = _showService.SaveShow(null, 1, 1, "nl", DateTime.Today.AddDays(1).AddHours(14).AddMinutes(00), true);

            Assert.AreEqual(0, result);
        }
    }
}
