using Plathe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    [Authorize]
    public class AdminShowController : Controller
    {
        private IShowRepository _repository;

        public AdminShowController(IShowRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index()
        {
            return View(_repository.Shows);
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
            return View("Edit", new Show());
        }
    }
}