using System.Web.Mvc;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Controllers
{
    public class CodeController : Controller
    {
        private readonly IReservationService _reservationService;

        public CodeController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: Code
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string code)
        {
            var reservationId = _reservationService.GetReservationIdByReservationCode(code);
            if (reservationId != 0)
            {
                return RedirectToAction("Printing", "Tickets", new { id = reservationId });
            } else {
                ViewData["NoResults"] = "De code die u heeft ingevoerd is onjuist, probeer opnieuw.";
                return View();
            }
        }
    }
}