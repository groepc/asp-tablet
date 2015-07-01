using System;
using System.Web.Mvc;
using Plathe.Backend.Models;

namespace Plathe.Backend.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            ShowFindViewModel viewModel = new ShowFindViewModel
            {
                StartTime = DateTime.Now.Date
            };
            return View(viewModel);
        }
    }
}