using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.Backend.Controllers
{
    [Authorize(Roles = "sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPostHandler()
        {
            return RedirectToAction("Print");
        }

        public ActionResult Print()
        {
            return View();
        }
    }
}