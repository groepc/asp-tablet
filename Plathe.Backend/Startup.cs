using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.Backend
{
    public class Startup
    {
        public static Func<UserManager<User>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/auth/login")
            });

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<User>(
                    new UserStore<User>(new EfDbContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<User>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                /* @todo nakijken wat we met de onderstaande string moeten */
                //usermanager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();

                return usermanager;
            };
        }
    }
}