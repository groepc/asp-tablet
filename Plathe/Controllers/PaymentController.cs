using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int? id)
        {
            return View();
        }
    }
}