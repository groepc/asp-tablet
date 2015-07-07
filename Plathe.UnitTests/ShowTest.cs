using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plathe.Domain.Abstract;
using Plathe.Domain.Concrete;
using Plathe.Domain.Services;

namespace Plathe.UnitTests
{
    [TestClass]
    class ShowTest
    {
        [TestMethod]
        public void AddShowInPast()
        {

            //Arrange - create a controller
            IShowRepository showRepository = new EfShowRepository();
            ShowService showService = new ShowService(showRepository);

            showService.SaveShow(1, 1, 1, "nl", new DateTime(2015, 01, 01), false);

            var result = showService.GetAllShows().ToArray();

            Assert.AreEqual(result.Length, 3);
        }
    }
}
