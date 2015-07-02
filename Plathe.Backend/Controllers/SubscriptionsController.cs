using System;
using System.Net;
using System.Web.Mvc;
using Plathe.Backend.Models;
using Plathe.Domain.Services;

namespace Plathe.Backend.Controllers
{
    [Authorize(Roles = "sales")]
    public class SubscriptionsController : Controller
    {

        private readonly SubscriptionService _subscriptionService;

        public SubscriptionsController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        // GET: Subscriptions
        public ActionResult Index()
        {
            SubscriptionListViewModel viewModel = new SubscriptionListViewModel();
            return View(viewModel);
        }

        public ActionResult Create()
        {
            SubscriptionCreateViewModel viewModel = new SubscriptionCreateViewModel();
            return View(viewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmd(string name, DateTime startDate, DateTime endDate)
        {

            var succesful = _subscriptionService.SaveSubscription(name, startDate, endDate);
            if (succesful)
            {
                TempData["message"] = "Abonnement toegevoegd";
                return RedirectToAction("Index");
            }

            SubscriptionCreateViewModel viewModel = new SubscriptionCreateViewModel();
            return View(viewModel);
        }

        public ActionResult Print(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   
            }

            
            SubscriptionPrintViewModel viewModel = new SubscriptionPrintViewModel
            {
                SubscriptionId = Convert.ToInt32(id)
            };

            return View(viewModel);
        }
    }
}