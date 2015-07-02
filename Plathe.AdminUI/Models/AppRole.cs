using Microsoft.AspNet.Identity.EntityFramework;

namespace Plathe.AdminUI.Models {
    public class AppRole : IdentityRole {

        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }
}
