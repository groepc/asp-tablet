using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Plathe.DAL;
using System.Web.Mvc;
using Plathe.Models;

namespace Plathe.Controllers
{
    public class ChooseForMeController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: ChooseForMe
        public ActionResult Index()
        {
            var show = db.Tickets
              .Include(t => t.Show)
              .Include(t => t.Reseveration)
              .Where(t => t.ShowID == t.Show.ShowID)
              .Where(t => t.ShowID == t.Show.ShowID)
              //.Where(s => s.StartingTime.Date >= today)
              //.OrderBy(t => t.Show.StartingTime)
              ;

            return View();
        }
    }
}