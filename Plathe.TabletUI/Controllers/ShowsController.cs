using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.TabletUI.Models;

namespace Plathe.TabletUI.Controllers
{
    public class ShowsController : Controller
    {
        //private EFDbContext db = new EFDbContext();
        //private IReservationService reservationService;
        private IShowService showService;

        public ShowsController(IShowService showService)
        {

        //    this.reservationService = reservationService;
            this.showService = showService;

        }

        // GET: Shows
        public ViewResult List()
        {
            ShowViewModel viewModel = new ShowViewModel();
            return View(viewModel);
        }
        // GET: Shows/TicketSelection/5
        public ViewResult TicketSelection(int? id)
        {
            // get current show
            Show show = showService.GetShowById((int)id);

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
                ShowId = show.ShowId
            };

            return View(viewModel);
        }
    }
}