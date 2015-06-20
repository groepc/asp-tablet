using System.Security.Claims;
using System.Web.Mvc;

namespace Plathe.Backend.Controllers
{
    public abstract class AppController : Controller
    {
        public UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(base.User as ClaimsPrincipal);
            }
        }
    }
}