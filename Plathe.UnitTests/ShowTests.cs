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
    public class ShowTests
    {
        [TestMethod]
        public void AddShowInPast()
        {

            Mock<IShowRepository> showMock = new Mock<IShowRepository>();
            showMock.Setup(m => m.Shows).Returns(new []
            {
                new Show
                {
                    ShowId = 1,
                    MovieId = 1,
                    RoomId = 1

                }
            });

            ShowService showService = new ShowService(showMock.Object);

            showService.SaveShow(1, 1, 1, "nl",  new DateTime(2015, 01, 01), false);

            var result = showService.GetAllShows().ToArray();

            Assert.AreEqual(result.Length, 1);
        }

        [TestMethod]
        public void AddShowOnSameTime()
        {

            Mock<IShowRepository> showMock = new Mock<IShowRepository>();
            showMock.Setup(m => m.Shows).Returns(new []
            {
                new Show
                {
                    ShowId = 1,
                    MovieId = 1,
                    RoomId = 1,
                    StartingTime = DateTime.Today.AddDays(1).AddHours(18).AddMinutes(30)

                }
            });

            ShowService showService = new ShowService(showMock.Object);

            showService.SaveShow(1, 1, 1, "nl", DateTime.Today.AddDays(1).AddHours(18).AddMinutes(30), false);

            var result = showService.GetAllShows().ToArray();

            Assert.AreEqual(result.Length, 1);
        }
    }
}
