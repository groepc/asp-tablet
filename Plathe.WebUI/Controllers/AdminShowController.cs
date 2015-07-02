using Plathe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    [Authorize]
    public class AdminShowController : Controller
    {
        private IShowRepository _repository;
        private EfDbContext _db = new EfDbContext();

        public AdminShowController(IShowRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index()
        {
            var shows = _db.Shows.Include(s => s.Movie).Include(s => s.Room);
            return View(shows.ToList());
        }

        public ViewResult Edit(int id)
        {
            Show show = _repository.Shows.FirstOrDefault(p => p.ShowId == id);
            return View(show);
        }

        [HttpPost]
        public ActionResult Edit(Show show)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveShow(show);
                TempData["message"] = string.Format("{0} is opgeslagen", show.ShowId);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(show);
            }
        }

        public ViewResult Create()
        {
            return View("Create", new Show());
        }

        //[HttpPost]
        //public ActionResult Create(Show show)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.SaveShow(show);
        //        TempData["message"] = string.Format("{0} is opgeslagen", show.ShowId);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(show);
        //    }
        //}
    }
}