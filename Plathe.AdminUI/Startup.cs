using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.AdminUI
{

    public class Startup
    {
        public static Func<UserManager<ApplicationUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            // configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new EfDbContext())
                );

                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<ApplicationUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }
    }
}