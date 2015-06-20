using System.Web.Mvc;

namespace Plathe.Backend.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}