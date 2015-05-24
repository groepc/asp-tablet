using Plathe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Models;

namespace Plathe.Controllers
{
    public class CodeController : Controller
    {

        private CinemaContext db = new CinemaContext();

        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckCode()
        {
            var uniqueCode = db.Reservations.Where(Reservation => Reservation.UniqueCode == Request.Form["code"]).Select(Reservation => Reservation.UniqueCode);
            string checkUniqueCode = "12345";
            if (!string.IsNullOrWhiteSpace(checkUniqueCode))
            {

                HttpContext.Response.Redirect("/Tickets/Printing");
            }

            return RedirectToAction("Index");
        }
    }
}