using System;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Web.Mvc;
using Plathe.Domain.Concrete;

namespace Plathe.Controllers
{
    public class PaymentController : Controller
    {

        private EfDbContext db = new EfDbContext();

        // GET: Payment
        public ActionResult Index(int? id)
        {
            ViewBag.idReservation = id;
            return View(db.Reservations.Find(id));
        }

        public ActionResult Ideal(int? id)
        {
            NameValueCollection data = Request.Form;
            ViewBag.bank = data["idealBank"];
            ViewBag.idReservation = id;
            return View(db.Reservations.Find(id));
        }

        public ActionResult Success(int id)
        {
            var reservation = db.Reservations.Find(id);

            if (reservation == null)
            {
                return HttpNotFound();
            }

            reservation.Payed = true;
            reservation.PayedOn = DateTime.Now;

            db.Entry(reservation).State = EntityState.Modified;
            db.SaveChanges();

            return View(reservation);
        }
    }
}