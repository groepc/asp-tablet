using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckCode()
        {
            if (Request.Form["code"] != null && !string.IsNullOrWhiteSpace(Request.Form["code"]))
            {

                HttpContext.Response.Redirect("/Tickets/Printing");
            }

            return RedirectToAction("Index");
        }
    }
}