using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.TabletUI.Models;
using Plathe.Domain.Concrete;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Controllers
{
    public class ShowsController : Controller
    {
        private EFDbContext db = new EFDbContext();
        private IShowRepository repository;

        public ShowsController(IShowRepository showRepository)
        {
            this.repository = showRepository;
        }

        // GET: Shows
        public ViewResult List()
        {
            var shows = repository.Shows;

            return View(shows.ToList());
        }
        // GET: Shows/TicketSelection/5
        public ActionResult TicketSelection(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // get current show
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            };

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
                Show = show,
                ShowId = show.ShowID
            };

            return View(viewModel);
        }
    }
}