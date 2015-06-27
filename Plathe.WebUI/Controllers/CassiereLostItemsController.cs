using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    [Authorize]
    public class CassiereLostItemsController : Controller
    {
        private ILostItemRepository _repository;

        public CassiereLostItemsController(ILostItemRepository repo)
        {
            _repository = repo;
        }

        // GET: CassiereLostItems
        public ActionResult Index()
        {
            return View(_repository.LostItems);
        }

        public ViewResult Edit(int id)
        {
            LostItem lostitem = _repository.LostItems.FirstOrDefault(p => p.LostItemId == id);
            return View(lostitem);
        }

        [HttpPost]
        public ActionResult Edit(LostItem lostitem)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveLostItem(lostitem);
                TempData["message"] = string.Format("{0} is opgeslagen", lostitem.LostItemId);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(lostitem);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new LostItem());
        }
    }
}