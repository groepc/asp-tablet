using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Plathe.AdminUI.Controllers {

    public class HomeController : Controller {

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
