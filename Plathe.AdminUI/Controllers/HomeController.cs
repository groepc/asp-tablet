using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Plathe.AdminUI.Controllers
{
    public class HomeController : AppController
    {
        // GET: Home
        /*   public ActionResult Index()
           {
               return View();
           }
           */
        /*
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            ViewBag.Country = claimsIdentity.FindFirst(ClaimTypes.Country).Value;

            return View();
        }
         */

        public ActionResult Index()
        {
            
            return View();
        }

    }
}