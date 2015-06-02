using Plathe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.Controllers
{
    public class PaymentController : Controller
    {

        private EFDbContext db = new EFDbContext();

        // GET: Payment
        public ActionResult Index(int? id)
        {
            ViewBag.idReservation = id;
            return View(db.Reservations.Find(id));
        }

        public ActionResult Ideal(int? id)
        {
            ViewBag.idReservation = id;
            return View(db.Reservations.Find(id));
        }

        public ActionResult Success(int? id)
        {
            return View(db.Reservations.Find(id));
        }
    }
}