using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    public class ShowsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Shows
        public ActionResult Index()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);

            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)tomorrow.DayOfWeek + 7) % 7;
            DateTime nextThursday = tomorrow.AddDays(daysUntilThursday);

            var shows = db.Shows
                .Where(s => s.StartingTime <= nextThursday )
                .Include(s => s.Movie);

            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
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
            }

            // get tickets for show
            var tickets = db.Tickets.Where(s => s.ShowID == show.ShowID);

            foreach (var row in show.Room.Rows)
            {
                foreach(var seat in row.Seats)
                {
                    bool isReserved = tickets.Any(t => t.SeatID == seat.SeatID);
                    if (isReserved) 
                    {
                        seat.Reserved = true;
                    }
                }
            }

            return View(show);
        }
    }
}
