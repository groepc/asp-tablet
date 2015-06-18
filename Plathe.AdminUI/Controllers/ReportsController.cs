using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Abstract;

namespace Plathe.AdminUI.Controllers
{
    [Authorize]
    public class ReportsController : AppController
    {
        private IShowRepository _showRepository;

        public ReportsController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}