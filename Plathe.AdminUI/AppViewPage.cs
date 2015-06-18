using System.Security.Claims;
using System.Web.Mvc;
using Plathe.AdminUI.Models;

namespace Plathe.AdminUI
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUserPrincipal CurrentUserPrincipal
        {
            get
            {
                return new AppUserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}


