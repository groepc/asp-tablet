using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Plathe.AdminUI.Models;

namespace Plathe.AdminUI.Controllers
{
    public abstract class AppController : Controller
    {
        public AppUserPrincipal CurrentUserPrincipal
        {
            get
            {
                return new AppUserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }
}