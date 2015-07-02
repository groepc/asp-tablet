using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Plathe.AdminUI.Models;
using Plathe.Domain.Concrete;
using Plathe.AdminUI.Models;

namespace Plathe.AdminUI.Infrastructure {

    public class AppRoleManager : RoleManager<AppRole>, IDisposable {

        public AppRoleManager(RoleStore<AppRole> store)
            : base(store) {
        }

        public static AppRoleManager Create(
                IdentityFactoryOptions<AppRoleManager> options,
                IOwinContext context) {
            return new AppRoleManager(new
                RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));
        }
    }
}
