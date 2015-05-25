using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.DAL;
using Plathe.Models;

namespace Plathe.Controllers
{
    public class ReservationController : Controller
    {

        private CinemaContext db = new CinemaContext();

        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}