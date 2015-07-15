using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plathe.AdminUI.Controllers;
using Plathe.AdminUI.Models;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.UnitTests
{
    [TestClass]
    public class ReportsControllerTests
    {
        [TestMethod]
        public void Occupation_ViewModel_Contains_Dates()
        {
            // arrange
            Mock<IShowService> mock = new Mock<IShowService>();
            ReportsController target = new ReportsController(mock.Object);

            // act
            var result = target.OccupationPerShow() as ViewResult;
            OccupationViewModel viewData = (OccupationViewModel) result.ViewData.Model;

            // assert
            Assert.AreEqual(viewData.ChosenDate, DateTime.Today);
            Assert.AreEqual(viewData.DayAfter, DateTime.Today.AddDays(1));
            Assert.AreEqual(viewData.DayBefore, DateTime.Today.AddDays(-1));
        }

        [TestMethod]
        public void Revenue_ViewModel_Contains_Dates()
        {
            // arrange
            Mock<IShowService> mock = new Mock<IShowService>();
            ReportsController target = new ReportsController(mock.Object);

            // act
            var result = target.Revenue() as ViewResult;
            RevenueViewModel viewData = (RevenueViewModel) result.ViewData.Model;

            // assert
            Assert.AreEqual(viewData.StartDate, new DateTime(2015, 1, 1));
            Assert.AreEqual(viewData.EndDate, DateTime.Today);
        }
    }
}
