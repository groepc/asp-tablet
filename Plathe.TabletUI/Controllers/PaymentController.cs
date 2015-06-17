using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.TabletUI.Controllers
{
    public class PaymentController : Controller
    {
        
        public ActionResult Index(int reservationId)
        {
            ViewBag.idReservation = reservationId;
            return View();
        }

    }
}