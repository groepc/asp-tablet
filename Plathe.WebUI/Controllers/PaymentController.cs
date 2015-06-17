using System;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Web.Mvc;
using Plathe.Domain.Concrete;

namespace Plathe.WebUI.Controllers
{
    public class PaymentController : Controller
    {

        private EfDbContext _db = new EfDbContext();

        // GET: Payment
        public ActionResult Index(int? id)
        {
            ViewBag.idReservation = id;
            return View(_db.Reservations.Find(id));
        }

        public ActionResult Ideal(int? id)
        {
            NameValueCollection data = Request.Form;
            ViewBag.bank = data["idealBank"];
            ViewBag.idReservation = id;
            return View(_db.Reservations.Find(id));
        }

        public ActionResult Success(int id)
        {
            var reservation = _db.Reservations.Find(id);

            if (reservation == null)
            {
                return HttpNotFound();
            }

            reservation.Payed = true;
            reservation.PayedOn = DateTime.Now;

            _db.Entry(reservation).State = EntityState.Modified;
            _db.SaveChanges();

            return View(reservation);
        }
    }
}