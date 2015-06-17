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
            // TODO: redirect to printing method
            return View();
        }

        public ActionResult Printing(int reservationId)
        {
            return View();
        }

    }
}